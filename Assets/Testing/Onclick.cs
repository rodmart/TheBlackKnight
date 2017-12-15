using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Onclick : MonoBehaviour {

	public void Clicked()
    {
        /*
        if(System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) > 1)
        {
            int tcount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
            this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
            PlayerHealth.curHealth = 200;
            print("clicked");
        }
        else
        {
            Destroy(this.gameObject);
        }
        */
        PlayerHealth.curHealth = PlayerHealth.curHealth + 10;
        Debug.Log("Clicked");
        Destroy(this.gameObject);
    }
}
