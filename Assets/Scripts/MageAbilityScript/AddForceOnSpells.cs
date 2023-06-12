using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddForceOnSpells : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float spellSpeed;

    [Header("Spell Icon")]
    [SerializeField] private string damageNumber;
    [SerializeField] private GameObject popNumbertext;



    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * spellSpeed, ForceMode.Impulse);
    }

  

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            
            Debug.Log("Enemy Collider, " + (collider.tag == "Enemy" && GameManager.instance.selectEnemy));

            if(MageInputManager.instance.fireSpell.name == "FireBoll")
            {
                MageInputManager.instance.CastingFireboll();
                GameManager.instance.DamageTheEnemy(MageInputManager.instance.fireSpell.damageAmount);
                Debug.Log("spell collids," + MageInputManager.instance.fireSpell);
            }
            
            Destroy(gameObject);
        }
    }

}
