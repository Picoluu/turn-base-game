using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour {


    public bool turn = false;

    List<Tile> selectableTiles = new List<Tile>();
    GameObject[] Tiles;

    Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;

    public bool moving = false;

    public int NpcMove = 1;
    public int move = 2;
    public float moveSpeed = 2f;
    public float jumpHight = 2f;
    

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0f;


    //Astar
    public Tile actualTargetTile;

    protected void Init()
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = GetComponent<Collider>().bounds.extents.y;

        TurnManager.AddUnit(this);
    }

    // func that finds the Tile currently under the player our the NPC

    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.current = true;
    }

       public Tile GetTargetTile(GameObject target)
       {
        RaycastHit Hit;
        Tile tile = null;
        if (Physics.Raycast(target.transform.position,-Vector3.up, out Hit))
        {
            tile = Hit.collider.GetComponent<Tile>();
            
        }

        return tile;
       }

    // finds adjacent Tiles to selected Tiles 

    public void ComputeAdjacencyLists(Tile target)
    {

        foreach (GameObject tile in Tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors(target);
        }
        
    }

    //finds the selectable Tiles

    public void FindSelectableTiles()
    {
        ComputeAdjacencyLists(null);
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();

        process.Enqueue(currentTile);
        currentTile.visited = true;
        

        while (process.Count > 0)
        {
            Tile t = process.Dequeue();

            selectableTiles.Add(t);
            t.selectable = true;
            if (t.distance < move)
            {

                foreach (Tile tile in t.adjacencyList)
                {
                    if (!tile.visited)
                    {
                        tile.parent = t;
                        tile.visited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);
                    }

                }
            }
        }

    }

    // character movement throw the Tiles 

    public void MoveToTile(Tile tile)
    {
        path.Clear();
        tile.target = true;
        moving = true;

        Tile next = tile;
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
            Tile t = path.Peek();
            Vector3 target = t.transform.position;

            //calculate the units position on top of the target Tile 
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
                //Tile center reached
                transform.position = target;
                path.Pop();

            }

        }
        else
        {
            RemoveSelectableTiles();
            moving = false;
            TurnManager.EndTurn();  
        }
    }

    // remove the selecteble Tiles while moving

    protected void RemoveSelectableTiles()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;
        }
        foreach (Tile tile in selectableTiles)
        {
            tile.Reset();
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


    // func that reterns the tile with the lowest vauled tile in the list 
    protected Tile FindLowestF(List<Tile> list)
    {
        Tile lowest = list[0];

        foreach (Tile t in list)
        {
            if (t.f < lowest.f)
            {
                lowest = t;
            }

        }

        // removing the lowest from the list 
        list.Remove(lowest);

        return lowest;
    }

    // finding the actual Target Tile were the target stands

    protected Tile FindEndTile(Tile t)
    {
        Stack<Tile> tempPath = new Stack<Tile>();

        Tile next = t.parent;
        while (next != null)
        {
            tempPath.Push(next);
            next = next.parent;
        }

        if (tempPath.Count <= NpcMove)
        {
            return t.parent;
        }

        Tile endTile = null;

        for (int i = 0; i <= NpcMove; i++)
        {
            endTile = tempPath.Pop();
        }

        return endTile;
    }
    

    // Astar algotrithem
    protected void FindPath(Tile target)
    {
        ComputeAdjacencyLists(target);
        GetCurrentTile();

        // tiles that have not been processed 
        List<Tile> openList = new List<Tile>();
        // tiles that have been processed
        List<Tile> closedList = new List<Tile>();

        openList.Add(currentTile);
        currentTile.h = Vector3.SqrMagnitude(target.transform.position  - currentTile.transform.position);
        currentTile.f = currentTile.h;


        // procesing the open list 
        while (openList.Count > 0)
        {
            //finding the lost value f in all the tiles in the open list 
            Tile t = FindLowestF(openList);
            // to prevent processing the same target a secend time we remove it to the close list 
            closedList.Add(t);

            // cheaking if the lowest value tile we found is the target tile 
            if (t == target)
            {
                //insted of moveing to the end tile (t) we will move to the tile infront of it 
              actualTargetTile = FindEndTile(t);
              MoveToTile(actualTargetTile);
                return;
            }

            // processing the adjacent tiles to t
            foreach (Tile tile in t.adjacencyList)
            {
                // the tile is in a closed list then do nothing 
                if (closedList.Contains(tile))
                {
                    // do nothing its already processed
                }
                // on an open list 
                else if (openList.Contains(tile))
                {
                    // cheaks if there is a faster way by compering the current position to a new position
                    // if it is set is as the new target 
                    float tempG =t.g + Vector3.Distance(tile.transform.position, t.transform.position);


                    if (tempG < tile.g)
                    {
                        tile.parent = t;

                        tile.g = tempG;
                        tile.f = tile.g + tile.h;
                    }


                }
                // not on both lists // if so we caculate its costs and add it to the open list 
                else
                {
                    tile.parent = t;

                    tile.g = t.g + Vector3.Distance(tile.transform.position, t.transform.position);
                    tile.h = Vector3.SqrMagnitude(target.transform.position - tile.transform.position);
                    tile.f = tile.g + tile.h;

                    openList.Add(tile);
                }

            }


        }
        // todo what do you do if there is no path to the target tile 
    }



    public void BeginTurn()
    {
        turn = true;
    }

    public void EndTurn()
    {
        turn = false;
    }
    // todo: end turn after an action not movement


}
