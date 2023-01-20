using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnSpells : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float spellSpeed;
    public ScriptableSpell spell;    
    

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

    void DealDamage(int amount)
    {    
        GameManager.instance.enemyCurrentHP -= amount;
        GameManager.instance.enemyHPSlider.value = amount;
        GameManager.instance.generalHPSlider.value = amount;

        Debug.Log(amount);

        if (GameManager.instance.enemyCurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        MageInputManager mageInput = GetComponent<MageInputManager>();

        if (collider.gameObject.tag == "Enemy" && GameManager.instance.selectEnemy != null)
        {
            Debug.Log("Enemy Collider" + collider.gameObject.tag == "Enemy");

            if (mageInput != null)
            {
                mageInput.CastingFireboll();
                mageInput.CastingIceSpell();
                DealDamage(10);
                Debug.Log("spell collids");
            }
            
            Destroy(gameObject);
        }
    }
}
