using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    [SerializeField] private Transform pfDamagePopUp;

    private TextMesh textMesh;
    private float disappearTimer;
    private Color textColor;


    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    //public static DamagePopUp Create(Vector3 position, int damageAmount)
    //{
    //    Transform damagePopupTransform = Instantiate(pfDamagePopUp, position, Quaternion.identity);

    //    DamagePopUp damagePopup = damagePopupTransform.GetComponent<DamagePopUp>();
    //    damagePopup.SetUp(damageAmount);

    //    return damagePopup;
    //}

    public void SetUp()
    {
        textMesh = transform.GetComponent<TextMesh>();
        disappearTimer = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pfDamagePopUp, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float moveYSpeed = 20f;
        transform.position = new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.time;
        if(disappearTimer > 0)
        {
            float disapearedSpeed = 3f;
            textColor.a -= disapearedSpeed * Time.deltaTime;
            textMesh.color= textColor;

            if(textColor.a > 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
