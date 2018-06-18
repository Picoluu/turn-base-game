using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : TacticsMove {

	
	void Start ()
    {
        Init();
	}
	
	
	void Update ()
    {
        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else
        {
            Move();
        }
        
	}

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    tile t = hit.collider.GetComponent<tile>();

                    if (t.selectable)
                    {

                        MoveToTile(t);
                    }

                }
               

            }

        }

    }
}
