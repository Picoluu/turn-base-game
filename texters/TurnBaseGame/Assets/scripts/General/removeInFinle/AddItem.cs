using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

    public Hero hero;

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("hero added" + hero.name);
            Inventory.instance.AddHero(hero);

        }

		
	}
}
