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
        int slotIndex = (int)newHero.Slot;
        currentEquiped[slotIndex] = newHero;
        Inventory.instance.RemoveHero(newHero);
    }


    public void UnEquip(Hero newHero)
    {
        currentEquiped[newHero.Slot] = null;
        Inventory.instance.AddHero(newHero);

    }

}

public enum ActionBarSlots {FirstHero,SecendHero,TheirdHero,ForthHero}



