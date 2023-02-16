using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AiPatrol : MonoBehaviour
{
    [Header("Patrol Area Check")]
    public Transform[] wayPoints;
    public int speed;
    public int wayPointIndex;
    public float distBetweenWayPoints;

    [Header("Distance Check")]
    public float lookRadius = 10f;
    public Transform target;   

    [Header("Enemy Attacking")]
    public bool alreadyAttacking = false;
    public float timeBetweenAttack = 1f;

    public float attackRange = 4f;
    public bool playerInSightRange, playerInAttackRange;

    public LayerMask whatIsPlayer;

    private Rigidbody aiRb;

 


    // Start is called before the first frame update
    void Start()
    {   
        aiRb = GetComponent<Rigidbody>();   

        target = GameManager.instance.player.transform;

        wayPointIndex = 0;
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, lookRadius, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //TestingBattleMode();      

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrol();
        }

        if (playerInSightRange && !playerInAttackRange)                                            // checking if player is with target radius
        {           
            ChasePlaye();            
        }       

        if (playerInAttackRange)
        {           
            AttackTarget();
        }
    }   
  

    void ChasePlaye()
    {        
        FaceTarget();           
    }

    void Patrol()
    {
        float range = 1f;              // range between each point.
        distBetweenWayPoints = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
        if (distBetweenWayPoints < range)
        {
            EnemyPatrolPoints();
        }        
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void AttackTarget()
    {
        
    }
    void ResetAttack()
    {
        alreadyAttacking = false;
    }

    void EnemyPatrolPoints()
    {
        wayPointIndex++;

        if (wayPointIndex >= wayPoints.Length)
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
