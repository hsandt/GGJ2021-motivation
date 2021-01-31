using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   
    
    public GameObject MenuCredits;
    public GameObject MainMenu;

    void Start()
    {
        MainMenu.SetActive(true);
        MenuCredits.SetActive(false);
    }
  
    public void OpenCredits()
    {
        
//        MainMenu.SetActive(false);
//        MenuCredits.SetActive(true);
    }

    public void CloseCredits()
    {
        MainMenu.SetActive(true);
        MenuCredits.SetActive(false);
    }

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
