using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
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
    Hero[] currentEquiped;

=======
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
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(ActionBarSlots)).Length;
        currentEquiped = new Hero[numSlots];
<<<<<<< HEAD
=======

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


>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
    }


    public void Equip(Hero newHero)
    {
<<<<<<< HEAD
        int slotIndex = (int)newHero.Slot;
        currentEquiped[slotIndex] = newHero;
        Inventory.instance.RemoveHero(newHero);
    }


    public void UnEquip(Hero newHero)
    {
        currentEquiped[newHero.Slot] = null;
<<<<<<< HEAD
        Inventory.instance.AddHero(newHero);
=======
       
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
        
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game

    }

<<<<<<< HEAD

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
<<<<<<< HEAD
<<<<<<< HEAD
=======
        Inventory.instance.AddHero(newHero);
=======
        int slotIndex = (int)newHero.Slot - 1;
>>>>>>> parent of 354d52a... drag n drop first fase

        currentEquiped[slotIndex -1] = newHero;
    }

>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58
=======
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
=======
>>>>>>> parent of e8f215a... action bar hero turns
=======
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
}

public enum ActionBarSlots {FirstHero,SecendHero,TheirdHero,ForthHero,NotOnActionBar}



