using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBarUI : MonoBehaviour {



    #region Singleton

    public static ActionBarUI instance;

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

    public Transform SlotsPerent;

   public SlotsActionBar [] slots;

   
    void Start ()
    {
        slots = SlotsPerent.GetComponentsInChildren<SlotsActionBar>();
       
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].slotPos = i;

            }
    }

	
	void Update () {
		
	}


    void UpdateUI()
    {


    }

}
