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

    // Update is called once per frame
    void Update()
    {
        if (PC)
        {
            if (mouseIn)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0)) //detect if you cliked in the PC
                {
                    PlayerController.Instance.GoingToPC = true;
                }
            }

        }



        if (Bed)
        {
            if (mouseIn)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))//detect if you cliked in the Bed
                {
                    PlayerController.Instance.GoingToBed = true;
                }
            }
        }
        
    }

    private void OnMouseEnter()
    {
        mouseIn = true;
        
    }

    private void OnMouseExit()
    {
        mouseIn = false;
    }
}
