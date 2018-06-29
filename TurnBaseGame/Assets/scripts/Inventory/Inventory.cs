using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    #region Singleton

    public static Inventory instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("more then one instance of inventory");
            return;
        }

        instance = this;
    }


    #endregion

    public delegate void OnHeroChange();
    public OnHeroChange onHeroChangeCallback;
    
    public int space = 15;

    public List<Hero> heroes = new List<Hero>();

    public bool AddHero(Hero hero)
    {
        if (heroes.Count >= space)
        {
            return false;
        }
        heroes.Add(hero);
        hero.currentTurn = false;

        if (onHeroChangeCallback != null)
        {
            onHeroChangeCallback.Invoke();
        }
       
        return true;
    }

    public void RemoveHero(Hero hero)
    {
        heroes.Remove(hero);

        if (onHeroChangeCallback != null)
        {
            onHeroChangeCallback.Invoke();
        }
    }
}
