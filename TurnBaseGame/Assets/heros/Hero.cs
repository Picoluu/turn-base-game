using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item",menuName = "ActionBar/Hero")]
public class Hero : ScriptableObject 
 {
<<<<<<< HEAD
    public bool currentTurn = false;
=======
>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58

    public int Slot;

    new public string name = "New item";
    public Sprite icon = null;

<<<<<<< HEAD
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
=======
    public void Selected()
    {
        
            DragAndDropManager.instance.SelectedHero(this);
            Debug.Log("Selecting" + name);
    }
       
 }
>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58


