using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour {


    private Color startColor;
    public bool walkable = true; 
    public bool current = false;
    public bool target = false;
    public bool selectable = false;


    public List<tile> adjacencyList = new List<tile>();

    //Needed BFS (a path finding algorithem)
    public bool visited = false;
    public tile parent = null;
    public int distance = 0;

	
	void Start ()
    {
        startColor = Resources.Load<Material>("Tile").color;
	}
	
   

	void Update ()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.black;
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
    }

    // finds adjacent tiles to the selected tile 
    public void FindNeighbors()
    {
        Reset();
        CheckTile(Vector3.forward * 1.5f);
        CheckTile(-Vector3.forward * 1.5f);
        CheckTile(Vector3.right * 1.5f);
        CheckTile(-Vector3.right * 1.5f);
    }

    // finds adjacent tiles to the selected tile
    public void CheckTile(Vector3 direction)
    {
        // checks for the adjacent tiles 
        Vector3 halfExtents = new Vector3(0.375f, 0.375f, 0.375f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);


        foreach (Collider item in colliders)
        {
            tile tiile = item.GetComponent<tile>();
            if (tiile !=  null && tiile.walkable)
            {
                RaycastHit hit;

                if (!Physics.Raycast(tiile.transform.position,Vector3.up, out hit , 1.5f))
                {
                    adjacencyList.Add(tiile);
                }

                
            }

        }



    }
    
}
