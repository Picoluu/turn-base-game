using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour {

    #region Singleton

    public static ActionBar instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("more then one instance of ActionBar");
            return;
        }

        instance = this;
    }





    #endregion

    Hero[] currentEquiped;


    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(ActionBarSlots)).Length;
        currentEquiped = new Hero[numSlots];
    }


    public void Equip(Hero newHero)
    {
        int slotIndex = (int)newHero.Slot - 1;

        currentEquiped[slotIndex -1] = newHero;
    }

}

public enum ActionBarSlots {FirstHero,SecendHero,TheirdHero,ForthHero,NotOnActionBar}



