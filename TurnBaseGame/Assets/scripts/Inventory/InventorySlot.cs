using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

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
        Inventory.instance.RemoveHero(hero);
    }

    public void SelectedHero()
    {
        if (hero != null)
        {
            hero.Selected();
        }

    }

}
