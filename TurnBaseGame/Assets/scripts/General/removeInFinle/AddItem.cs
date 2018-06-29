using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

    public Hero hero;

    private void Start()
    {
<<<<<<< HEAD
        Debug.Log("hero added" + hero.name);
        Inventory.instance.AddHero(hero);
=======
        foreach (Hero t in heroes)
        {
            Debug.Log("hero added" + t.name);
            Inventory.instance.AddHero(t);
        }
        
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
    }

}
