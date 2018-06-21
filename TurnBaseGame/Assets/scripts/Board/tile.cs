using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {


    private Color startColor;

    public bool walkable = true; 
    public bool current = false;
    public bool target = false;
    public bool selectable = false;

    public List<Tile> adjacencyList = new List<Tile>();

    //Needed BFS (a path finding algorithem)
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;


    // Needed for Astar
    // f = g + h
    public float f = 0;
    // g is the cost from the perent to the corrent tile 
    public float g = 0;
    // h is the cost of the current tile to the destanation
    public float h = 0;

	
	void Start ()
    {
        startColor = Resources.Load<Material>("Tile").color;
	}
	
   

	void Update ()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = startColor;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = startColor;
        }
	}

    // helper func
    //every turn we will need to define every veruable again

    public void Reset()
    {

     adjacencyList.Clear();

     //selecting veruables
      walkable = true;
      current = false;
      target = false;
     selectable = false;

     //Veruables BFS
     visited = false;
     parent = null;
     distance = 0;

     // Veruables Astar

        f = g = h = 0;
    }

    // sets adjacent Tiles to the selected Tile 
    public void FindNeighbors(Tile target)
    {
        Reset();
        CheckTile(Vector3.forward * 1.5f, target);
        CheckTile(-Vector3.forward * 1.5f, target);
        CheckTile(Vector3.right * 1.5f, target);
        CheckTile(-Vector3.right * 1.5f, target);
    }

    // func that finds adjacent Tiles
    public void CheckTile(Vector3 direction, Tile target)
    {
        // checks for the adjacent Tiles 
        Vector3 halfExtents = new Vector3(0.375f, 0.375f, 0.375f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        
        foreach (Collider item in colliders)
        {
            Tile tile = item.GetComponent<Tile>();
            if (tile !=  null && tile.walkable)
            {
                RaycastHit hit;

                if (!Physics.Raycast(tile.transform.position,Vector3.up, out hit , 1.5f) || (tile == target) )
                {
                    adjacencyList.Add(tile);
                }

                
            }

        }



    }
    
}
