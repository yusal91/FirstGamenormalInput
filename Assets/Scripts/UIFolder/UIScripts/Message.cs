using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Message : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject);
        //Destroy(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

}
