using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

    public List<Hero> heroes;

    private void Start()
    {
<<<<<<< HEAD
        foreach (Hero t in heroes)
        {
            Debug.Log("hero added" + t.name);
            Inventory.instance.AddHero(t);
        }
        
=======
        Debug.Log("hero added" + hero.name);
        Inventory.instance.AddHero(hero);
>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58
    }

}
