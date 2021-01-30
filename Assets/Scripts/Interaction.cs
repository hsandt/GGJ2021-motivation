using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{


    public GameObject PCInteractions;
    public GameObject BedInteractions;




    // Start is called before the first frame update
    void Start()
    {
        PCInteractions.SetActive(false);
        BedInteractions.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerController.Instance.IsOnPC == true)
        {
            PCInteractions.SetActive(true);
         
        }
        else
        {
            PCInteractions.SetActive(false);

        }

        if (PlayerController.Instance.IsOnBed == true)
        {
            BedInteractions.SetActive(true);
       
        }
        else
        {
            BedInteractions.SetActive(false);
        }







    }
}
