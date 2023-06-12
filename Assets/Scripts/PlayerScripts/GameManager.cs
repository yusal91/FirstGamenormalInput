using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Transform")]
    public GameObject player;
    public GameObject enemy;

    [Header("Enemy Object Settings")]
    public GameObject enemyHealthbar;
    public GameObject selectedTargetedHPBarObject;
    [Header("Enemy Slider")]
    public Slider enemyHPSlider;
    public Slider selectedTargetHPBar;
    public int enemyCurrentHP, enemyMaxHP;
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
        SetMaxHealth(enemyMaxHP);
    }

    public void SetMaxHealth(int health)
    {
        selectedTargetHPBar.maxValue = health;
        enemyHPSlider.maxValue = health;

        selectedTargetHPBar.value = health;
        enemyHPSlider.value = health;        
    }

    public void SetHealth(int health)
    {
        selectedTargetHPBar.value = health;
        enemyHPSlider.value = health;
        
        Debug.Log("Damage done to the Enemy ," + enemyHPSlider.value);
        Debug.Log("Damage done to the Enemy ," + selectedTargetHPBar.value);
    }

    // Update is called once per frame
    void Update()
    {
        WoldMapButton();

        if (Input.GetMouseButtonDown(0))
        {
            SelectTarget();
        }
        if (selectEnemy != null && Input.GetKeyDown(KeyCode.Tab))
        {
            DeSelectTarget();
            Debug.Log("Target Removed");
        }
        if (selectEnemy != null && twiceClickedTimer > 0)
        {
            twiceClickedTimer -= Time.deltaTime;
            //Debug.Log("Clicked Twice" + twiceClickedTimer);
        }
        else
        {
            haveClickedTwice = false;
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

    public void SelectTarget()
    {
        Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))  // 1000 is distance but will adjust later on 
        {
            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("Target Selected, " + (hit.transform.tag == "Enemy"));
                enemyHealthbar.SetActive(true);
                selectedTargetedHPBarObject.SetActive(true);
                selectEnemy = hit.transform.gameObject;
            }
        }
        else
        {
            if (selectEnemy != null)
            {
                if (haveClickedTwice == false)
                {
                    haveClickedTwice = true;
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
        selectedTargetedHPBarObject.SetActive(false);
    }

    public void DamageTheEnemy(int damageEnemy)
    {
        enemyCurrentHP -= damageEnemy;
        SetHealth(enemyCurrentHP);

        Debug.Log("current Enemy HP ," + enemyCurrentHP);
        Debug.Log("Damage done to the Enemy ," + damageEnemy);  

        if (enemyCurrentHP <= 0)
        {
            Debug.Log("Enemy has no hp left, " + enemyCurrentHP);
            DeSelectTarget();
            Destroy(enemy);
        }
    }
}
