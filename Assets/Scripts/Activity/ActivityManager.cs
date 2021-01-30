using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsPattern;
using UnityConstants;

public class ActivityManager : SingletonManager<ActivityManager>
{
    /* Cached children references */

    /// Array of activities in no specific order, holes in ID are also possible
    private Activity[] m_Activities;
    
    /// Dictionary of activity ID to Activity, derived from m_Activities
    private readonly Dictionary<int, Activity> m_ActivitiesMap = new Dictionary<int, Activity>();


    private void Awake()
    {
        RegisterAllActivities();
    }

    private void RegisterAllActivities()
    {
        GameObject activitiesParent = GameObject.FindWithTag(Tags.Activities);
        if (activitiesParent)
        {
            m_Activities = activitiesParent.GetComponentsInChildren<Activity>();
            
            foreach (Activity activity in m_Activities)
            {
                m_ActivitiesMap[activity.ID] = activity;
            }
        }
        else
        {
            Debug.LogError("No game object found with tag Activities, cannot register activities.");
        }
    }
    
    public Activity GetActivity(int id)
    {
        return m_ActivitiesMap[id];
    }
    
    public void StartActivity(int id)
    {
        m_ActivitiesMap[id].Execute();
    }
}
