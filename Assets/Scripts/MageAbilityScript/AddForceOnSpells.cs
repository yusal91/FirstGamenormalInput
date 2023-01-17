using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnSpells : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float spellSpeed;
    

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
}
