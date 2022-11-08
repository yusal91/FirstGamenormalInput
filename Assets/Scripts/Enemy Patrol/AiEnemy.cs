using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{
    //public LayerMask whatIsGround, whatIsPlayer;
    //public Transform player;

    //public Vector3 walkPoint;
    //public bool walkPointSet;
    //public float walkPointRange;

    //public float timeBetweenAttacks;
    //public bool alreadyAttacked;

    //public float sightRange, attackRange;
    //public bool playerInSightRange, playerInAttackRange;

    //private void Awake()
    //{
    //    player = GameManager.instance.player.transform;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
    //    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

    //    if (!playerInSightRange && !playerInAttackRange) Patroling();
    //    if (playerInSightRange && !playerInAttackRange) ChasePlayer();
    //    if (playerInSightRange && playerInAttackRange) AttackPlayer();

    //}

    //void Patroling()
    //{
    //    if (!walkPointSet) SearchWalkPoint();

    //    if(walkPointSet)
    //    {
    //        //Patrolcode here
    //    }

    //    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //    if(distanceToWalkPoint.magnitude > 1f)
    //    {
    //        walkPointSet = false;
    //    }
    //}

    //void SearchWalkPoint()
    //{
    //    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //    float randomX = Random.Range(-walkPointRange, walkPointRange);

    //    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //    {
    //        walkPointSet = true;
    //    }
    //}
    //void ChasePlayer()
    //{
    //    //chaseplayer code here
    //}
    //void AttackPlayer()
    //{
    //    // need code to have enemy stop close to player if enemy is melee or Range
    //    transform.LookAt(player);

    //    if(!alreadyAttacked)
    //    {
    //        // attack code here


    //        alreadyAttacked = true;
    //        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    //    }
    //}

    //void ResetAttack()
    //{
    //    alreadyAttacked = false;
    //}

    //public void TakeDamage(int damage)
    //{
    //    //health -= damage;

    //    //if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    //}

    //public void DestroyEnemy()
    //{
    //    Destroy(gameObject);            // for later not now
    //}

}
