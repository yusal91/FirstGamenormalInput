using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WMScript : MonoBehaviour
{
    public static WMScript instance;

    public GameObject toolTipCanvas;

    public GameObject areYouShowObject;
    public Button yesButton;
    public Button noButton;


    private void Awake()
    {
        instance = this;
    }

    public void YesButtonToChangeScene()
    {
        Debug.Log("Game Scene");
        SceneManager.LoadScene("GameScene");

        //Scene scene = SceneManager.GetSceneByName("GameScene");
        //SceneManager.SetActiveScene(scene);
    }   
}
