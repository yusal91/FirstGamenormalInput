using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleMode
{
    None,
    InBattle,
    OutOfBattle,
}

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

    [Header("Enemy Attacking")]
    public bool alreadyAttacking = false;
    public float timeBetweenAttack = 1f;

    public float attackRange = 2f;
    public bool playerInSightRange, playerInAttackRange;

    public LayerMask whatIsPlayer;

 


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
        playerInSightRange = Physics.CheckSphere(transform.position, lookRadius, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        float range = 1f;
        dist = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
        if (dist < range)
        {
            IncreaseIndex();            
        }

        if (!playerInSightRange && !playerInAttackRange)
        {
            playerInSightRange = false;
            playerInAttackRange = false;            
        }


        if (playerInSightRange && !playerInAttackRange)                                            // checking if player is with target radius
        {
            playerInSightRange = true;
            playerInAttackRange = false;
            ChasePlaye();
        }

        if (playerInAttackRange)
        {
            playerInAttackRange = true;
            AttackTarget();
        }        
    }

    void ChasePlaye()
    {        
        transform.LookAt(target);        
        transform.position += target.position * attackRange * Time.deltaTime;
        FaceTarget();
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
        Gizmos.color = Color.red;        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {     
        Vector3 dirction = (target.position - transform.position).normalized;
        Quaternion looktRotation = Quaternion.LookRotation(new Vector3(dirction.x, 0, dirction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, looktRotation, Time.deltaTime * 5f);
    }    
}
