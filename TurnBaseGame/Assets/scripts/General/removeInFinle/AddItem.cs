using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

    public List<Hero> heroes;

    private void Start()
    {
        foreach (Hero t in heroes)
        {
            Debug.Log("hero added" + t.name);
            Inventory.instance.AddHero(t);
        }
        
    }

}
