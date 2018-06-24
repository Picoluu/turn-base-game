using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item",menuName = "ActionBar/Hero")]
public class Hero : ScriptableObject
 {

    public ActionBarSlots Slot = ActionBarSlots.NotOnActionBar;

    new public string name = "New item";
    public Sprite icon = null;

    public virtual void Use()
    {
        // useing the hero (probly equping to actionBar)
        // add a reference to action bar andd add the hero to it 

        Debug.Log("equping" + name);
    }

 }
