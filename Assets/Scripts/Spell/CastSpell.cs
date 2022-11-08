using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public ScriptableSpell spellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = spellToCast.spellRadius;

        myRigidbody = GetComponent<Rigidbody>();    
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, spellToCast.lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (spellToCast.speed > 0) 
        {
            transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
