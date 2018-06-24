using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {


    Inventory Inventory;
	
	void Start () {
        Inventory = Inventory.instance;

        Inventory.onHeroChangeCallback += UpdateUI;
    }
	
	
	void Update () {
		
	}


    void UpdateUI()
    {
        Debug.Log("updating UI");  
    }
}
