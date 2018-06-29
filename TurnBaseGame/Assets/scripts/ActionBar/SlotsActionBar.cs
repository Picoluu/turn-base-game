using UnityEngine.UI;
using UnityEngine;

public class SlotsActionBar : MonoBehaviour {

    public int slotPos;

    public Image icon;
    public Button removeButton;

    Hero hero;

   


    public void AddHero(Hero newhero)
    {
        hero = newhero;
        icon.sprite = hero.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
   

    public void ClearSlot()
    {
        hero = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
   
    public void OnRemoveButton()
    {
        Inventory.instance.AddHero(hero);
<<<<<<< HEAD
        // remove from array currentEquiped
=======
        ActionBar.instance.UnEquip(hero);      
        ClearSlot();
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
    }

    // when the button is pressed 
    public void EquipHero()
    {
        if (DragAndDropManager.instance.currentSelectedHero != null)
        {
            hero = DragAndDropManager.instance.currentSelectedHero;
            // setting the heroes Slot to the slotPos of the Slot
            hero.Slot = slotPos;
            ActionBar.instance.Equip(hero);
            AddHero(hero);
<<<<<<< HEAD
        }
        DragAndDropManager.instance.currentSelectedHero = null;

    }

=======
            ActionBar.instance.SetFirstTurn();
        }
        DragAndDropManager.instance.UnSelecteHero();

    }
    
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game


}
