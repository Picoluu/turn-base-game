using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58
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

<<<<<<< HEAD
    public Hero[] currentEquiped;
    public int numberOfHero;

    private bool partyIsFull = false;

    private void Update()
    {
        Debug.Log(numberOfHero);
        HeroWithCurrentTurn(currentEquiped);
        CheckIfPartyFull();
    }

    public void SetFirstTurn()
    {
        if (currentEquiped.First() != null)
        {
            if (currentEquiped.First().currentTurn == false)
            {
                currentEquiped.First().currentTurn = true;
            }
            else return;

        }
    }
=======
    Hero[] currentEquiped;

>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(ActionBarSlots)).Length;
        currentEquiped = new Hero[numSlots];
<<<<<<< HEAD

    }

    private void CheckIfPartyFull()
    {
        for (int i = 0; i < currentEquiped.Length; i++)
        {
            if (currentEquiped[i] == null)
            {
                partyIsFull = false;
                break;

            }
            else
            {
                partyIsFull = true;

            }
        }


=======
>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58
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
<<<<<<< HEAD
       
    }


    public int HeroWithCurrentTurn(Hero[] Heros)
    {

        if (partyIsFull)
        {
            foreach (Hero t in Heros)
            {
                if (t.currentTurn == true)
                {
                    numberOfHero = t.Slot;

                }

            }
        }
        

        return numberOfHero;
    }


    public void HeroesTurnEnder()
    {
        foreach (Hero t in currentEquiped)
        {
            if (t.currentTurn == true)
            {

                Debug.Log("current turn of " + t.name);


                // reset
                if (t.Slot == currentEquiped.Last().Slot)
                {
                    Debug.Log("B");
                    // this func is not triggering
                }
                else
                {                   
                    currentEquiped[t.Slot + 1].currentTurn = true;                    
                }

                Debug.Log(ActionBar.instance.numberOfHero);
                currentEquiped[t.Slot].currentTurn = false;
                break;
            }
        }

    }
=======
        Inventory.instance.AddHero(newHero);

    }

>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58
}

public enum ActionBarSlots {FirstHero,SecendHero,TheirdHero,ForthHero}



