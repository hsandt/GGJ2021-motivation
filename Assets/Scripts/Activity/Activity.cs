using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public abstract class Activity : MonoBehaviour
{
    [Header("Parameters")]
    
    [SerializeField, Tooltip("Activity ID")]
    private int id = -1;
    public int ID => id;

    public abstract void Execute();
}
