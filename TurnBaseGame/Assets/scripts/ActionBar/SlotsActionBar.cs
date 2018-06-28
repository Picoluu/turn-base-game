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
        ActionBar.instance.UnEquip(hero);      
        ClearSlot();
=======
        // remove from array currentEquiped
>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58
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
            ActionBar.instance.SetFirstTurn();
        }
        DragAndDropManager.instance.UnSelecteHero();

    }
    
=======
        }
        DragAndDropManager.instance.currentSelectedHero = null;

    }

>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58


}
