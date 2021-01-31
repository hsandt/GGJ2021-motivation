using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   
    
    public GameObject MenuCredits;
    public GameObject MainMenu;

    // Start is called before the first frame update
    void Start()

    {
        
        MainMenu.SetActive(true);
        MenuCredits.SetActive(false);
  

    }

    // Update is called once per frame
    void Update()
    {

    }
  
    public void OpenCredits()
    {
        
        MainMenu.SetActive(false);
        MenuCredits.SetActive(true);

    }

    public void VoltarMenu()
    {
        
        MainMenu.SetActive(true);
        MenuCredits.SetActive(false);
       

    }


    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
