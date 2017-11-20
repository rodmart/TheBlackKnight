using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInventory : MonoBehaviour {
    public GameObject inventoryUI;
    // Use this for initialization
    void Start () {
        inventoryUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if(inventoryUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.I))    
                inventoryUI.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
                inventoryUI.SetActive(true);
        }

    }
}
