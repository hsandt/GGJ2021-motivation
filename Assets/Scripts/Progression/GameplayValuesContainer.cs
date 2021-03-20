using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;

public class GameplayValuesContainer : MonoBehaviour
{
    /* Cached data references */

    /// Array of session gameplay data, indexed by SessionGameplayValueType
    private SessionGameplayValueData[] m_SessionGameplayDataArray;
    
    /// Array of chapter gameplay data, indexed by ChapterGameplayValueType
    private ChapterGameplayValueData[] m_ChapterGameplayDataArray;
    
    
    /* State */
    
    private GameplayValue<SessionGameplayValueType>[] m_SessionGameplayValues;
    private GameplayValue<ChapterGameplayValueType>[][] m_ChapterGameplayValuesPerChapter;


    public GameplayValue<SessionGameplayValueType> GetSessionGameplayValue(SessionGameplayValueType type)
    {
        return m_SessionGameplayValues[(int)type];
    }
    
    public GameplayValue<ChapterGameplayValueType> GetChapterGameplayValue(int chapterIndex, ChapterGameplayValueType type)
    {
        return m_ChapterGameplayValuesPerChapter[chapterIndex][(int)type];
    }

    public void CreateGameplayValueArrays(DifficultySetting difficultySetting)
    {
        // construct array content early so other objects can register to them
        // we can even Init them, as observers will be smart enough to do an initial refresh as they missed the first value change
        m_SessionGameplayDataArray = LoadSpecificGameplayDataArray<SessionGameplayValueData, SessionGameplayValueType>("Session");
        m_SessionGameplayValues = new GameplayValue<SessionGameplayValueType>[m_SessionGameplayDataArray.Length];
        for (int i = 0; i < m_SessionGameplayValues.Length; i++)
        {
            m_SessionGameplayValues[i] = new GameplayValue<SessionGameplayValueType>();
            m_SessionGameplayValues[i].Init(m_SessionGameplayDataArray[i], difficultySetting.level);
        }
        
        m_ChapterGameplayDataArray = LoadSpecificGameplayDataArray<ChapterGameplayValueData, ChapterGameplayValueType>("Chapter");
        m_ChapterGameplayValuesPerChapter = new GameplayValue<ChapterGameplayValueType>[difficultySetting.chaptersCount][];
        for (int chapterIndex = 0; chapterIndex < difficultySetting.chaptersCount; ++chapterIndex)
        {
            m_ChapterGameplayValuesPerChapter[chapterIndex] = new GameplayValue<ChapterGameplayValueType>[m_ChapterGameplayDataArray.Length];
            for (int i = 0; i < m_ChapterGameplayValuesPerChapter[chapterIndex].Length; i++)
            {
                m_ChapterGameplayValuesPerChapter[chapterIndex][i] = new GameplayValue<ChapterGameplayValueType>();
                m_ChapterGameplayValuesPerChapter[chapterIndex][i].Init(m_ChapterGameplayDataArray[i], difficultySetting.level);
            }
        }
    }

    /// Load all gameplay data resources (session or chapter, based on passed generic arguments)
    /// and return an array of them, indexed by (session or chapter) gameplay value type.
    /// If data assets are missing, there will be holes (null entry), but type enum index remains reliable. 
    private TGameplayValueTypeData[] LoadSpecificGameplayDataArray<TGameplayValueTypeData, TGameplayValueType>(string resourceFolderName)
        where TGameplayValueTypeData : GameplayValueData<TGameplayValueType>
    {
        TGameplayValueTypeData[] gameplayDataResources = Resources.LoadAll<TGameplayValueTypeData>($"GameplayValues/{resourceFolderName}");

        // get gameplay data as resources, but they are unordered (actually alphabetical order,
        // but not reliable for enum ordering as we don't prefix them with digits and there could be holes)
        var gameplayDataArray = new TGameplayValueTypeData[EnumUtil.GetCount<TGameplayValueType>()];

        foreach (TGameplayValueTypeData gameplayData in gameplayDataResources)
        {
            int typeIndex = gameplayData.TypeIndex;
            if (typeIndex < gameplayDataArray.Length)
            {
                gameplayDataArray[typeIndex] = gameplayData;
            }
            else
            {
                Debug.LogErrorFormat(gameplayData,
                    "gameplayData.type {0} index {1} is not less than " +
                    "count of TGameplayValueType enum variants {2}.",
                    gameplayData.type, typeIndex, gameplayDataArray.Length);
            }
        }

        for (int i = 0; i < gameplayDataArray.Length; ++i)
        {
            if (gameplayDataArray[i] == null)
            {
                Debug.LogErrorFormat("No GameplayValueTypeData found in GameplayValues/{0} for type index {1}", resourceFolderName, i);
            }
        }

        return gameplayDataArray;
    }
}
