using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public bool mouseIn;

    public bool Bed;
    public bool PC;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // OnPointerClick callback
    public void OnClick()
    {
        PlayerController.Instance.GoingToPC = true;
    }
}
