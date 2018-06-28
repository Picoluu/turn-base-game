using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour {

    #region Singleton

    public static DragAndDropManager instance;

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

    public Hero currentSelectedHero;


    public void SelectedHero(Hero hero)
    {
        currentSelectedHero = hero;
        
    }

    public void UnSelecteHero()
    {
        currentSelectedHero = null;
    }
    
}
