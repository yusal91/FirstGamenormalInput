using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Transform")]
    public GameObject player;


    [Header("Enemy Settings")]
    public GameObject enemyHealthbar;   
    public GameObject generalTargetedHPBar;
    [SerializeField] public Slider enemyHPSlider;
    [SerializeField] public Slider generalHPSlider;
    [SerializeField] public int enemyCurrentHP, enemyMaxHP;   
    public GameObject selectEnemy;

    [Header("Other Settings")]
    [SerializeField] bool haveClickedTwice;
    [SerializeField] float twiceClickedTimer;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHP = enemyMaxHP;
        enemyHPSlider.value = enemyMaxHP;
        generalHPSlider.value = enemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        WoldMapButton();

        if(Input.GetMouseButtonDown(0))
        {
            SelectTarget();
        }
        if(selectEnemy != null && Input.GetKeyDown(KeyCode.Tab))
        {
            DeSelectTarget();
            Debug.Log("Target Removed");
        }
        if(selectEnemy != null && twiceClickedTimer > 0)
        {
            twiceClickedTimer -= Time.deltaTime;
            //Debug.Log("Clicked Twice" + twiceClickedTimer);
        }
        else
        {
            haveClickedTwice= false;
            //Debug.Log("HaveClicked Twice" + haveClickedTwice);
        }

    }

    void WoldMapButton()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M Button Pressed");
            // will change and add this to a gameobject or if you want to leave current wold to next world
            SceneManager.LoadScene("WorldMap");
        }
    }

    void SelectTarget()
    {
        Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000))  // 1000 is distance but will adjust later on 
        {
            if(hit.transform.tag == "Enemy")
            {
                Debug.Log(hit.transform.tag == "Enemy");
                enemyHealthbar.SetActive(true);
                generalTargetedHPBar.SetActive(true);
                selectEnemy = hit.transform.gameObject;
            }
        }
        else
        {
            if(selectEnemy != null)
            {
               if(haveClickedTwice == false)
                {
                    haveClickedTwice= true;
                    twiceClickedTimer = 1f;
                }
               else
                {
                    Debug.Log("Removed Target By Click Twice");                    
                    twiceClickedTimer = 0;
                    DeSelectTarget();
                }
            }
        }
    }

    void DeSelectTarget()
    {
        selectEnemy = null;
        enemyHealthbar.SetActive(false);
        generalTargetedHPBar.SetActive(false);
    }       
}
