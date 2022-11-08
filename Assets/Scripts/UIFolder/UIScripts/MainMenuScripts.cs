using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScripts : MonoBehaviour
{
    private PlayerManager playerManager;


    
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }



    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //playerManager.EnableGameplayControls();
    }
    public void LoadGame()
    {
        Debug.Log("LoadGame");
    }
    public void Configuration()
    {
        Debug.Log("Configuration");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
