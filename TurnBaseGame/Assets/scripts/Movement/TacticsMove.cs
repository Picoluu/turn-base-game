using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour {

    List<tile> selectableTiles = new List<tile>();
    GameObject[] tiles;

    Stack<tile> path = new Stack<tile>();
    tile currentTile;

    public bool moving = false;

    public int move = 2;
    public float moveSpeed = 2f;
    public float jumpHight = 2f;
    

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0f;

    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = GetComponent<Collider>().bounds.extents.y;

    }

    // func that finds the tile currently under the player our the NPC

    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.current = true;
    }

       public tile GetTargetTile(GameObject target)
       {
        RaycastHit Hit;
        tile tiile = null;
        if (Physics.Raycast(target.transform.position,-Vector3.up, out Hit))
        {
            tiile = Hit.collider.GetComponent<tile>();
            
        }

        return tiile;
       }

    // finds adjacent tiles to selected tiles 

    public void ComputeAdjacencyLists()
    {

        foreach (GameObject tiile in tiles)
        {
            tile t = tiile.GetComponent<tile>();
            t.FindNeighbors();
        }
        
    }

    //finds the selectable tiles

    public void FindSelectableTiles()
    {
        ComputeAdjacencyLists();
        GetCurrentTile();

        Queue<tile> process = new Queue<tile>();

        process.Enqueue(currentTile);
        currentTile.visited = true;
        // currentTile.parent = ?? leave as null

        while (process.Count > 0)
        {
            tile t = process.Dequeue();

            selectableTiles.Add(t);
            t.selectable = true;
            if (t.distance < move)
            {

                foreach (tile tiile in t.adjacencyList)
                {
                    if (!tiile.visited)
                    {
                        tiile.parent = t;
                        tiile.visited = true;
                        tiile.distance = 1 + t.distance;
                        process.Enqueue(tiile);
                    }

                }
            }
        }

    }

    // character movement throw the tiles 

    public void MoveToTile(tile tiile)
    {
        path.Clear();
        tiile.target = true;
        moving = true;

        tile next = tiile;
        while (next != null )
        {
            path.Push(next);
            next = next.parent;
        }
    }

    public void Move()
    {
        if (path.Count > 0)
        {
            tile t = path.Peek();
            Vector3 target = t.transform.position;

            //calculate the units position on top of the target tile 
            target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

            if (Vector3.Distance(transform.position, target) >= 0.05f)
            {
                CalculateHeading(target);
                SetHorizotalVelocity();

                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;

            }
            else
            {
                //tile center reached
                transform.position = target;
                path.Pop();

            }

        }
        else
        {
            RemoveSelectableTiles();
            moving = false;

        }
    }

    // remove the selecteble tiles while moving

    protected void RemoveSelectableTiles()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;
        }
        foreach (tile tiile in selectableTiles)
        {
            tiile.Reset();
        }

        selectableTiles.Clear();
    }

    void  CalculateHeading(Vector3 target)
    {
        heading = target - transform.position;
        heading.Normalize();

    }

    void SetHorizotalVelocity()
    {
        velocity = heading * moveSpeed;
    }
}
