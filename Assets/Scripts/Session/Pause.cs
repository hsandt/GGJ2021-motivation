using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused;

    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            Paused();
        }
        else
        {
            Play();
        }
        
    }

    public void Paused()
    {
        //Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
