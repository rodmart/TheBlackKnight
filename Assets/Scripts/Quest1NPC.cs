using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Quest1NPC : MonoBehaviour {

    public float rangeDistance;
    public Transform NPC;
	public float interaction;
    public Transform player;
	private int timesTalked = 0;
	private int conversation = 0;
	public Text quest1;
	public Image box;
	private int onQuest =0;
	private int enemies;

	

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		Canvas quest = GetComponent<Canvas>();
		AudioSource audio = GetComponent<AudioSource>();
		GameObject[] trolls = GameObject.FindGameObjectsWithTag("Trolls");
		enemies = trolls.Length;

		
		//start dialogue
        if ((Distance() <= rangeDistance) && (timesTalked == 0) && (onQuest==0))
        {
            audio.Play();
			quest1.text= "That troll kidnapped my daughter! \n";
			quest1.text+= "Please help!";
			box.enabled=true;
			timesTalked = 1;
        }
		
		if((Distance() <=interaction) && (timesTalked ==1))
		{
			if(Input.GetKeyDown(KeyCode.Mouse0)){
					quest1.text = "Will you help? \n";
					quest1.text+= "(Y)es or (N)o";
					conversation = 1;
	
				}
				if(conversation==1){
					if(Input.GetKeyDown(KeyCode.Y)){
						quest1.text = "I hope you make it in time...";
						onQuest = 1;
					}
					if(Input.GetKeyDown(KeyCode.N))quest1.text = "I hope someone will help me then...";
				}
				
		}
		
		if((onQuest==1) && (timesTalked == 0) && (enemies >= 1))
		{
			box.enabled = true;
			quest1.text = "I hope you haven't given up on my daughter";
		}
		
		if((onQuest==1) &&(timesTalked ==0) && (enemies ==0))
		{
			box.enabled = true;
			quest1.text = "Thank you so much!";
		}
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			quest1.text = "";
			box.enabled=false;
			timesTalked =0;
			conversation=0;

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, NPC.position);
    }
}
