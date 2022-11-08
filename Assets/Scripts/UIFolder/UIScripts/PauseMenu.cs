using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    
    public bool gameIsPaused;


    void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gameIsPaused)
            {
                Paused();
            }
            else
            {
                ResumeGame();
            }
        }       
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;        
        Time.timeScale = 0f;
        Debug.Log("Game is Paused and Time Frozen");
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;        
        Time.timeScale = 1f;        
        Debug.Log("Resumed Game and Time unFrozen");
    }
    public void Quit()
    {
        Application.Quit();
    }    
}
