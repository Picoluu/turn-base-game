using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item",menuName = "ActionBar/Hero")]
public class Hero : ScriptableObject
 {

    public ActionBarSlots Slot = ActionBarSlots.NotOnActionBar;

    new public string name = "New item";
    public Sprite icon = null;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
     void Awake()
    {
        currentTurn = false;
    }

=======
>>>>>>> parent of e8f215a... action bar hero turns
    public void Selected()
    {
        
            DragAndDropManager.instance.SelectedHero(this);
            Debug.Log("Selecting" + name);
    }
<<<<<<< HEAD


}
<<<<<<< HEAD
=======
    public void Selected()
    {
        
            DragAndDropManager.instance.SelectedHero(this);
            Debug.Log("Selecting" + name);
    }
       
 }
>>>>>>> 354d52a9260a1a6d2dce1ed5d0588bdd1ebdcb58
=======
    public virtual void Use()
    {
        // useing the hero (probly equping to actionBar)
        // add a reference to action bar andd add the hero to it 
>>>>>>> parent of 354d52a... drag n drop first fase
=======
>>>>>>> parent of 2b5624f... Merge branch 'master' of https://github.com/Picoluu/turn-base-game
=======
       
 }
>>>>>>> parent of e8f215a... action bar hero turns

        Debug.Log("equping" + name);
    }

 }
