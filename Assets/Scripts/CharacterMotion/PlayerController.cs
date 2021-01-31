using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public GameObject PC;
    public GameObject Bed;
    private NavMeshAgent navMesh;

    public bool canMove;

    public bool GoingToPC;
    public bool GoingToBed;

    public bool IsOnPC;
    public bool IsOnBed;




    //public Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        if (Instance == null)
            Instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
        navMesh = GetComponent<NavMeshAgent>();
      
        canMove = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            navMesh.speed = 4;
        }
        else
        {
            navMesh.speed = 0;

        }




        if (GoingToBed)
        {
            canMove = true;
            navMesh.destination = Bed.transform.position;
            if (Vector3.Distance(transform.position, Bed.transform.position) < 5.5f)
            {
                
              IsOnBed = true;
                canMove = false;
            }
            else
            {
                IsOnBed = false;
            }
        }
        if (GoingToPC)
        {
            canMove = true;
            navMesh.destination = PC.transform.position;
            if (Vector3.Distance(transform.position, PC.transform.position) < 5.5f)
            {

                IsOnPC = true;
                canMove = false;
            }
            else
            {
                IsOnPC = false;
            }
        }


        if (IsOnBed){

            GoingToBed = false;
            //canMove = false;
        }

        if (IsOnPC)
        {
            GoingToPC = false;
            //canMove = false;

        }


       


    }


}
