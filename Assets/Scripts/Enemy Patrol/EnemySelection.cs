using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class EnemySelection : MonoBehaviour
{
    public Camera cam;
    private enemyInVeiw target;       // need to make script

    public GameObject targetCrossHeir;

    public int lockedEnemy;
    public bool lockedOn;
    public static List<enemyInVeiw> nearByEnemies = new List<enemyInVeiw>();



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetCrossHeir = gameObject.GetComponent<GameObject>();

        lockedEnemy = 0;
        lockedOn = false;
    }

    //public void SelectingEnemies()
    //{  
    //    //if (collision.gameObject.tag ==  "EnemyTarget")

    //    if(!lockedOn && collision.gameObject.tag != "EnemyTarget")
    //    {
    //        if(context.performed && nearByEnemies.Count >= 1)
    //        {
    //            lockedOn = true;
    //            targetCrossHeir.SetActive(true);

    //            lockedEnemy = 0;
    //            target = nearByEnemies[lockedEnemy];
    //        }
    //    }
    //    else if(context.performed && lockedOn || nearByEnemies.Count == 0)
    //    {
    //        lockedOn = false;
    //        targetCrossHeir.SetActive(false);
    //        lockedEnemy = 0;
    //        target = null;
    //    }        
    //}
    //public void AlreadySelectedEnemy()
    //{
    //    if (context.performed && lockedEnemy == nearByEnemies.Count - 1)
    //    {
    //        lockedEnemy = 0;
    //        target = nearByEnemies[lockedEnemy];
    //    }
    //    else
    //    {
    //        lockedEnemy++;
    //        target = nearByEnemies[lockedEnemy];
    //    }
    //    if (lockedOn)
    //    {
    //        target = nearByEnemies[lockedEnemy];
    //        gameObject.transform.position = cam.WorldToScreenPoint(target.transform.position);
    //        gameObject.transform.Rotate(new Vector3(0, 0, -1));
    //    }
    //}
}
