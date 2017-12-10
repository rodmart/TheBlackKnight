using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CouplesMale : MonoBehaviour {

private float rangeDistance;
    private Transform player;
	public int conversation = 0;
	public Text textBox;
	public Image box;

	// Use this for initialization
	void Start () {
		rangeDistance=7;
		player = GameObject.FindWithTag("Player").transform;
		conversation = Random.Range(1,7);
	}
	
	// Update is called once per frame
	void Update () {
		//start dialogue
        if ((Distance() <= rangeDistance) && (conversation == 1))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "Yeah, but sometimes they know interesting facts.\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 2))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I heard the black knight used to be nice...\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 3))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "Must have been bad parenting. \n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 4))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I wonder if the kingdom will send troops..\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 5))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "Maybe something tragic happened to the black knight..\n";
			box.enabled=true;
        }

		if ((Distance() <= rangeDistance) && (conversation == 6))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "If we make it out alive..\n";
			box.enabled=true;
        }		
		
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			textBox.text = "";
			box.enabled=false;
			GetComponent<Animation>().Play("idle");
			conversation = Random.Range(1,7);

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}

