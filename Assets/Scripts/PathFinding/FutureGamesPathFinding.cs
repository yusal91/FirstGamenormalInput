using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutureGamesPathFinding : MonoBehaviour
{
    public Vector3Int start;
    public Vector3Int end;

    public List<Vector3> path;

    private void OnDrawGizmos()
    {
        path = FindPath(start, end);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(start, .5f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(end, .5f);

        if(path == null)
        {
            return;
        }
        Gizmos.color = Color.white;  

        for (int i = 0; i < path.Count - 1; i++)
        {
            Gizmos.DrawLine(path[i], path[i + 1]);
        }
    }

    public class Node
    {
        public float gCost;        //distance from postion node
        public float hCost;        // distance from destination
        public float fCost => gCost + hCost;
        public Vector3 postion;
        public Node parent;

        public Node(Vector3 postion, Vector3 destination, Node parent = null)
        {                                        
            this.postion = postion;
            this.parent = parent;

            this.gCost = this.parent != null? this.parent.gCost + Vector3.Distance(this.postion, this.parent.postion) : 0f;
            this.hCost = Vector3.Distance(this.postion, destination);
        }
        public override bool Equals(object obj) => obj is Node n ? this.Equals(n) : false;

        public bool Equals(Node other) => this.postion.Equals(other.postion);

        public override int GetHashCode() => this.postion.GetHashCode();
    }

    public List<Vector3> FindPath(Vector3 start, Vector3 destination)
    {
        List<Vector3> path = new List<Vector3>();

        List<Node> openList = new List<Node>();
        List<Node> closeList = new List<Node>();

        Node startNode = new Node(start, destination);

        openList.Add(startNode);

        while(openList.Count != 0)
        {
            Node current = this.GetNodeWithLowestFCost(openList);

            if(current.postion == destination)
            {
                return ContructPath(current);
            }

            openList.Remove(current);
            closeList.Add(current);

            Vector3[] neihbouringPostion = this.GetNeighbouringPostions(current.postion);

            foreach(Vector3 postion in neihbouringPostion)
            {
                Node neighboringNode = new Node(postion, destination, current);

                bool isBlocked = Physics.CheckBox(neighboringNode.postion, Vector3.one * 0.5f);

                if (isBlocked || closeList.Contains(neighboringNode))
                {
                    continue;
                }

                if(!openList.Contains(neighboringNode))
                {
                    openList.Add(neighboringNode); 
                }
                else
                {
                    Node openNode = openList.Find(x => x.postion == neighboringNode.postion);

                    if(openNode.gCost > neighboringNode.gCost)
                    {
                        openNode.parent = neighboringNode.parent;
                        openNode.gCost = neighboringNode.gCost;
                    }
                }
            }

        }

        Debug.LogWarning("Could not find Path");

        return null;
    }

    private Node GetNodeWithLowestFCost(List<Node> nodes)
    {
        if (nodes.Count == 0)
        {
            Debug.LogError("List is Empty");            
        }
        Node lowestFCostNode = nodes[0];

        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = nodes[i];
            }
        }
        return lowestFCostNode;
    }

    private List<Vector3> ContructPath(Node finalNode)
    {
        List<Vector3> path = new List<Vector3>();

        Node currentNode = finalNode;

        while(currentNode != null)
        {
            path.Add(currentNode.postion);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }

    private Vector3[] GetNeighbouringPostions(Vector3 postion)
    {
        Vector3[] result = new Vector3[8];

        result[0] = postion + Vector3.forward;
        result[1] = postion + Vector3.back;
        result[2] = postion + Vector3.left;
        result[3] = postion + Vector3.right;

        result[4] = postion + Vector3.forward + Vector3.left;
        result[5] = postion + Vector3.forward + Vector3.right;
        result[6] = postion + Vector3.forward + Vector3.left;
        result[7] = postion + Vector3.forward + Vector3.right;

        return result;
    }
}
