using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

    public Hero hero;

    private void Start()
    {
        Debug.Log("hero added" + hero.name);
        Inventory.instance.AddHero(hero);
    }

}
