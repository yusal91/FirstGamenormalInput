using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;    
   

    void Awake()
    {
        instance = this;
    }
}
