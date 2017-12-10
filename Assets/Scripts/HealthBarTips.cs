using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTips : MonoBehaviour {

	private float rangeDistance;
	private float interaction;
    private Transform player;
	private int timesTalked = 0;
	public Text textBox;
	public Image box;

	// Use this for initialization
	void Start () {
		rangeDistance=7;
		interaction = 5;
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//start dialogue
        if ((Distance() <= rangeDistance) && (timesTalked == 0))
        {
			AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I heard fighting raises your stamina.\n";
			textBox.text+="Maybe that woud mean your health increases.";
			box.enabled=true;
			timesTalked = 1;
        }
		
		if((Distance() <=interaction) && (timesTalked ==1))
		{
			GetComponent<Animation>().Play("dialog");
			if(Input.GetKeyDown(KeyCode.E)){
					textBox.text = "Maybe fighting all the goblins would do that..\n";
	
				}
				
		}
		
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			textBox.text = "";
			box.enabled=false;
			timesTalked =0;
			GetComponent<Animation>().Play("idle");

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}

