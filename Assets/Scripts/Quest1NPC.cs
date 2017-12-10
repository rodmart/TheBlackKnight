using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Quest1NPC : MonoBehaviour {

    private float rangeDistance;
	private float interaction;
    private Transform player;
	private int timesTalked = 0;
	private int conversation = 0;
	public Text quest1;
	public Image box;
	public int onQuest =0;
	public int questCompleted = 0;
	private int enemies;

	

    // Use this for initialization
    void Start () {
		rangeDistance=7;
		interaction = 5;
		player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
		GameObject[] goblins = GameObject.FindGameObjectsWithTag("Goblins");
		enemies = goblins.Length;

		
		//start dialogue
        if ((Distance() <= rangeDistance) && (timesTalked == 0))
        {
			AudioSource audio = GetComponent<AudioSource>();
			quest1.text = "Hello\n";
			box.enabled=true;
			GetComponent<Animation>().Play("dialog");
			
			if(Input.GetKeyDown(KeyCode.E)){
				timesTalked = 1;
				audio.Play();
				}
        }
		
		if((Distance() <=interaction) && (timesTalked ==1)&& (onQuest==0))
		{
			GetComponent<Animation>().Play("dialog");
			if(Input.GetKeyDown(KeyCode.E)){
					quest1.text = "Will you help me slay the goblins? \n";
					quest1.text+= "(Y)es or (N)o";
					conversation = 1;
	
				}
				if(conversation==1){
					if(Input.GetKeyDown(KeyCode.Y)){
						quest1.text = "I hope you make it in time";
						onQuest = 1;
					}
					if(Input.GetKeyDown(KeyCode.N))quest1.text = "I hope someone will help me then...";
				}
				
		}
		
		if((onQuest==1) && (timesTalked == 1) && (enemies >= 1))
		{
			GetComponent<Animation>().Play("dialog");
			box.enabled = true;
			quest1.text = "There's still " + enemies +" goblin(s) left to slay.";
		}
		
		if((onQuest==1) &&(timesTalked ==1) && (enemies ==0))
		{
			GetComponent<Animation>().Play("dialog");
			box.enabled = true;
			quest1.text = "Thank you so much!";
			questCompleted = 1;
		}
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			quest1.text = "";
			box.enabled=false;
			timesTalked =0;
			conversation=0;
			GetComponent<Animation>().Play("idle");

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}
