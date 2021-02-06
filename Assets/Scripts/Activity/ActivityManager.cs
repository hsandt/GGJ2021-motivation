using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsPattern;
using UnityConstants;

public class ActivityManager : SingletonManager<ActivityManager>
{
    /* Cached data references */

    private ActivityData[] m_ActivityDataArray;
    
    
    /* Cached children references */

    /// Dictionary of activity ID to Activity, derived from m_Activities
    private readonly Dictionary<int, ActivityBehaviour> m_ActivityBehavioursMap = new Dictionary<int, ActivityBehaviour>();


    /* Cached external references */

    public Animator m_PlayerCharacterAnimator;
    public Animator m_ActivityItemsAnimator;

    
    /* External references with fallback */

    [Tooltip("Command popup: if not set, find object with tag, but doesn't work if object is inactive")]
    public CommandPopUp commandPopUp;


    protected override void Init()
    {
        // Activity data store all serializable data
        m_ActivityDataArray = Resources.LoadAll<ActivityData>("Activities");
        
        // For the rest, we use activity behaviour objects, which are located under the same parent
        // and just have an ActivityBehaviour script that contains the behaviour to Execute (not serializable)
        // Each ActivityBehaviour is associated to an activity data, and reverse mapping is stored using ID.
        RegisterAllActivityBehaviours();
        
        // check that each Activity Data has a matching behaviour
        foreach (ActivityData activityData in m_ActivityDataArray)
        {
            if (!m_ActivityBehavioursMap.ContainsKey(activityData.id))
            {
                Debug.LogErrorFormat(activityData, "m_ActivityBehavioursMap has not key {0}, " +
                    "which means activity data with this ID has no matching behaviour.",
                    activityData.id);
            }
        }

        if (commandPopUp == null)
        {
            GameObject commandPopUpGameObject = GameObject.FindWithTag(Tags.CommandPopUp);
            if (commandPopUpGameObject)
            {
                commandPopUp = commandPopUpGameObject.GetComponent<CommandPopUp>();
            }
            else
            {
                Debug.LogError("No game object found with tag CommandPopUp, cannot set commandPopUp.");
            }
        }
    }

    private void Start()
    {
        // copy cached references already set on SessionManager (at Awake time)
        m_PlayerCharacterAnimator = SessionManager.Instance.playerCharacterAnimator;
        m_ActivityItemsAnimator = SessionManager.Instance.activityItemsAnimator;
        
        HideCommandPopUp();
    }

    private void RegisterAllActivityBehaviours()
    {
        GameObject activitiesParent = GameObject.FindWithTag(Tags.Activities);
        if (activitiesParent)
        {
            ActivityBehaviour[] activityBehaviours = activitiesParent.GetComponentsInChildren<ActivityBehaviour>();
            
            foreach (ActivityBehaviour activityBehaviour in activityBehaviours)
            {
                if (m_ActivityBehavioursMap.ContainsKey(activityBehaviour.data.id))
                {
                    Debug.LogErrorFormat(activityBehaviour,
                        "m_ActivityBehavioursMap already contains key activity.data.id {0}, " +
                        "but activity behaviour {1} also references this ID.",
                        activityBehaviour.data.id, activityBehaviour);
                    continue;
                }
                
                m_ActivityBehavioursMap[activityBehaviour.data.id] = activityBehaviour;
            }
        }
        else
        {
            Debug.LogError("No game object found with tag Activities, cannot register activities.");
        }
    }

    public void ShowCommandPopUp(ActivityData[] activityDataArray)
    {
        commandPopUp.ShowWithActivities(activityDataArray);
    }
    
    public void HideCommandPopUp()
    {
        commandPopUp.Hide();
    }
    
    public void StartActivity(int id)
    {
        ActivityBehaviour activityBehaviour = m_ActivityBehavioursMap[id];
        
        // play animation (it just shows the relevant pose mesh) and hide activity items already embedded in that character pose
        m_PlayerCharacterAnimator.SetInteger(AnimatorParameters.poseIndexHash, (int)activityBehaviour.data.characterPoseEnum);
        m_ActivityItemsAnimator.SetInteger(AnimatorParameters.poseIndexHash, (int)activityBehaviour.data.characterPoseEnum);
        
        // execute gameplay effect
        activityBehaviour.Execute();
        
        HideCommandPopUp();
    }

    public void OnActivityTransitionEnd()
    {
        
    }
}
