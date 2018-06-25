using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item",menuName = "ActionBar/Hero")]
public class Hero : ScriptableObject
 {

    public int Slot;

    new public string name = "New item";
    public Sprite icon = null;

    public void Selected()
    {
        
            DragAndDropManager.instance.SelectedHero(this);
            Debug.Log("Selecting" + name);
    }
       
 }


