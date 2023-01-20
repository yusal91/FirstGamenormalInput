using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageInputManager : MonoBehaviour
{
    [Header("Spell Counts and Damage OverTime")]
    public List<int> damgOverTime = new List<int>();
    [SerializeField] int spellCount = 0;
    [SerializeField] int blizardSpellCount = 0;
    [Header("Casting Position")]
    [SerializeField] Transform castingPoint;
    [SerializeField] GameObject fireBollPrefab;    
    [SerializeField] GameObject iceBollPrefab;    

    [Header("Spell")]
    public ScriptableSpell fireSpell;
    public ScriptableSpell blizardSpell;
    public ScriptableSpell thunderSpell;
    public ScriptableSpell layLineSpell;
    [Header("Spell")]
    [SerializeField] bool fireBlastReady;
    [SerializeField] float speed;
    [Header("Spell Icon")]
    [SerializeField] Image fireboll_GCD;
    [SerializeField] Image fireBlastIMG;
    [SerializeField] Image blizardGCD;
    [SerializeField] Image frozenIMG;
    [SerializeField] Image thunderGCD;
    [SerializeField] Image thunder2IMG;
    [SerializeField] Image laylineIMG;
    [SerializeField] Image laylineCooldownIMG;
   


    // Start is called before the first frame update
    void Start()
    {
        InitSpell();
    }

    void InitSpell()
    {
        fireboll_GCD.fillAmount = 0;
        blizardGCD.fillAmount = 0;
        thunderGCD.fillAmount = 0;

        castingPoint = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CastingFireboll();
        CastingIceSpell();
      

        if (Input.GetKeyDown(KeyCode.R))
        {
            ApplyLightningDamage(thunderSpell.damageOverTime);
            // need to make so i can cast the spell
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            // burst damage buff      
            layLineSpell.PutOnCooldown();
            laylineCooldownIMG.fillAmount = layLineSpell.maxCooldown;
            Debug.Log(layLineSpell);
        }
    }   
    
    public void CastingFireboll()
    {     
        if (Input.GetKeyUp(KeyCode.Q) && GameManager.instance.selectEnemy != null) 
        {  
            if (fireSpell.currentCooldown <= 0 && fireboll_GCD.fillAmount == 0)
            {                
                Debug.Log("FireButton Pressed" + fireSpell.currentCooldown);
                Debug.Log("FireButton Pressed" + fireSpell.maxCooldown);
                //FireSpell
                
                Instantiate(fireBollPrefab, castingPoint.position, Quaternion.LookRotation
                           (GameManager.instance.selectEnemy.transform.position - castingPoint.position));                

                spellCount++;
                
                fireboll_GCD.fillAmount = 1f;
                blizardGCD.fillAmount = 1;
                thunderGCD.fillAmount = 1;
            }
        }

        if(fireSpell.maxCooldown >= 1 && blizardSpell.maxCooldown >= 1 && thunderSpell.maxCooldown >= 1)
        {            
            fireboll_GCD.fillAmount -= 1 / fireSpell.maxCooldown * Time.deltaTime;
            blizardGCD.fillAmount -= 1 / blizardSpell.maxCooldown * Time.deltaTime; 
            thunderGCD.fillAmount -= 1 / thunderSpell.maxCooldown * Time.deltaTime; 

            if (fireboll_GCD.fillAmount <= 0  && blizardGCD.fillAmount <= 0 && thunderGCD.fillAmount <= 0)
            {                
                fireboll_GCD.fillAmount = 0;
                blizardGCD.fillAmount = 0;
                thunderGCD.fillAmount = 0;
            }
        }
        StartCoroutine(FireBlastReadyToUse());
    }

    IEnumerator FireBlastReadyToUse()
    {
        while (spellCount == 3)
        {
            Debug.Log("FireBlast can be used");
            fireboll_GCD.fillAmount = 0;
            fireBlastIMG.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                spellCount = 0;
                yield return new WaitForSeconds(fireboll_GCD.fillAmount = 1);
                fireBlastIMG.gameObject.SetActive(false);
            }  
            yield return new WaitForSeconds(0.75f);
        }
    }

    public  void CastingIceSpell()
    {   
        if (Input.GetKeyUp(KeyCode.E) && GameManager.instance.selectEnemy != null && blizardSpell.currentCooldown <= 0 && blizardGCD.fillAmount == 0)
        {
            //Ice/BlizzardSpell
            Instantiate(iceBollPrefab, castingPoint.position, Quaternion.LookRotation
                       (GameManager.instance.selectEnemy.transform.position - castingPoint.position));    // will see if it works with out Qutarionen.Identity
            blizardSpellCount++;

            fireboll_GCD.fillAmount = 1f;
            blizardGCD.fillAmount = 1;
            thunderGCD.fillAmount = 1;

            if (blizardSpellCount == 3)
            {
                Debug.Log("IceStrom can be used");
                blizardSpellCount = 0;
            }

            if (fireSpell.maxCooldown >= 1 && blizardSpell.maxCooldown >= 1 && thunderSpell.maxCooldown >= 1)
            {
                fireboll_GCD.fillAmount -= 1 / fireSpell.maxCooldown * Time.deltaTime;
                blizardGCD.fillAmount -= 1 / blizardSpell.maxCooldown * Time.deltaTime;
                thunderGCD.fillAmount -= 1 / thunderSpell.maxCooldown * Time.deltaTime;

                if (fireboll_GCD.fillAmount <= 0 && blizardGCD.fillAmount <= 0 && thunderGCD.fillAmount <= 0)
                {
                    fireboll_GCD.fillAmount = 0;
                    blizardGCD.fillAmount = 0;
                    thunderGCD.fillAmount = 0;
                }
            }
        }
    }

    public void ApplyLightningDamage(int ticks)
    {
        if (damgOverTime.Count <= 0)
        {
            // start corutine 
            damgOverTime.Add(ticks);
            StartCoroutine(LightningDamage());
        }
        else
        {
            // dont start
            damgOverTime.Add(ticks);
        }
    }

    IEnumerator LightningDamage()
    {
        while (damgOverTime.Count > 0)
        {
            for (int i = 0; i < damgOverTime.Count; i++)
            {
                damgOverTime[i]++;
            }
            // here i write damage to the enemy

            damgOverTime.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);   // null isnt option for this need to check and do the look again;
        }
    }
}
