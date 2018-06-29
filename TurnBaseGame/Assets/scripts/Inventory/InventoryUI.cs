using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform herosPerent;
    public GameObject inventoryUI;

    Inventory Inventory;

    InventorySlot[] slots;
	
	void Start () {
        Inventory = Inventory.instance;

        Inventory.onHeroChangeCallback += UpdateUI;

        slots = herosPerent.GetComponentsInChildren<InventorySlot>();
    }
	
	
	void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}


    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.heroes.Count)
            {
                slots[i].AddHero(Inventory.heroes[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }
}
