using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [Header("Dash Setting")]
    public Slider dashSlider;
    public float currentStamina, maxStamina = 100;   
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;    

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        dashSlider.maxValue = maxStamina;
        dashSlider.value= maxStamina;
        currentStamina = maxStamina;
    }

    private void Update()
    {
     
    }

    public void UseStminaWhenDash(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount * Time.deltaTime;
            dashSlider.value = currentStamina;

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Cant Dash");
        }
        
    }
    IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            //currentStamina++;                           // may not need it
            currentStamina += maxStamina / 100;
            dashSlider.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }

    public void ButtonPressToActiveMenu(GameObject menuObject)
    {
        menuObject.SetActive(!menuObject.activeSelf);
    }

}
