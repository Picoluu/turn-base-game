using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item",menuName = "ActionBar/Hero")]
public class Hero : ScriptableObject 
 {
    public bool currentTurn = false;

    public int Slot;

    new public string name = "New item";
    public Sprite icon = null;

     void Awake()
    {
        currentTurn = false;
    }

    public void Selected()
    {       
            DragAndDropManager.instance.SelectedHero(this);
            Debug.Log("Selecting" + name);
    }


}


