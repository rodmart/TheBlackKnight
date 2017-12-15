using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingInventory : MonoBehaviour {
    public GameObject inventoryUI;
    public bool paused;

    // Use this for initialization
    void Start () {
        inventoryUI.SetActive(false);
        paused=false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene("Menu");
        }

        if(inventoryUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
               
                inventoryUI.SetActive(false);
            }
            //inventoryUI.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
                inventoryUI.SetActive(true);
        }
       if (Input.GetKeyDown(KeyCode.P)){ 
                 paused = !paused;
             }
        
        if (paused) {
            Time.timeScale = 0f;
            }
         else if(!paused)
         {
            Time.timeScale=1f;
         }
        

    }
}
