using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : TacticsMove
{
    GameObject target;

	
	void Start ()
    {
        Init();
	}
	
	void Update ()
    {
        if (!turn)
        {
            return;
        }


        if (!moving)
        {
            FindNearestTarget();
            CalculatePath();
           // FindSelectableTiles();
            actualTargetTile.target = true;
           
        }
        else
        {
            Move();
        }
    }

    void CalculatePath()
    {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile);

    }
    
    void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        //finds the closest target to the Npc

        GameObject nearest = null;
        // algorithm to find the closest obj
        float distance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }

        }

        target = nearest;
    }

}
