using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingEnemy : MonoBehaviour
{
    public FutureGamesPathFinding findPath;
    public GameObject cubeObject;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SearchWalkPoint();
    }
    

    void SearchWalkPoint( )
    {
        walkPoint = new Vector3(cubeObject.transform.position.x + findPath.start.x, 0, 
                                cubeObject.transform.position.z + findPath.start.z); 

        walkPoint.x = Random.Range(transform.position.x + findPath.end.x, walkPointRange);
        walkPoint.z = Random.Range(transform.position.z + findPath.end.z, walkPointRange);

        walkPoint = new Vector3(transform.position.x + walkPoint.x, transform.position.y, transform.position.z + walkPoint.z);
        

        //if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        //{
        //    walkPointSet = true;
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }
}
