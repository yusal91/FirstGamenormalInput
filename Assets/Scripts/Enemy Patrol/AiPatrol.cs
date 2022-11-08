using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AiPatrol : MonoBehaviour
{
    [Header("Patrol Area Check")]
    public Transform[] wayPoints;
    public int speed;
    public int wayPointIndex;
    public float dist;

    [Header("Distance Check")]
    public float lookRadius = 10f;
    public Transform target;
    public float distanceToTarget = 8f;
    public bool targetNotInRange = false;

    [Header("Enemy Attacking")]
    public bool alreadyAttacking = false;
    public float timeBetweenAttack = 1f;

    private EnemySelection enemySelection;

    //public float sightRange, attackRange;
    //public bool targetInSightRange, targetInAttackRange;   


    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.transform;

        wayPointIndex = 0;
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        float range = 1f;
        dist = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
        if (dist < range)
        {
            IncreaseIndex();
        }
        Patrol();

        distanceToTarget = Vector3.Distance(transform.position, target.position);        

        if (distanceToTarget <= lookRadius)
        {
            targetNotInRange = true;
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
            FaceTarget();           
        }
        else if(distanceToTarget >= lookRadius)
        {
            targetNotInRange = false;            
            transform.LookAt(wayPoints[wayPointIndex].position);
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void AttackTarget()
    {

    }
    void ResetAttack()
    {
        alreadyAttacking = false;
    }

    void IncreaseIndex()
    {
        wayPointIndex++;
        if(wayPointIndex >= wayPoints.Length)
        {
            wayPointIndex = 0;
        }
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {     
        Vector3 dirction = (target.position - transform.position).normalized;
        Quaternion looktRotation = Quaternion.LookRotation(new Vector3(dirction.x, 0, dirction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, looktRotation, Time.deltaTime * 5f);
    }    
}
