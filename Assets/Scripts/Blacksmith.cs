using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Blacksmith : MonoBehaviour {


    public float rangeDistance;
    public Transform NPC;
	public float interaction;
    public Transform player;
	private int timesTalked = 0;
	private int conversation = 0;
	public Text quest1;
	public Image box;
	private int onQuest =0;
	public int questCompleted = 0;
	private int enemies;

	

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		Canvas quest = GetComponent<Canvas>();
		AudioSource audio = GetComponent<AudioSource>();
		GameObject[] metals = GameObject.FindGameObjectsWithTag("collectables");
		enemies = metals.Length;

		
		//start dialogue
        if ((Distance() <= rangeDistance) && (timesTalked == 0) && (onQuest==0))
        {
            audio.Play();
			GetComponent<Animation>().Play("dialog1");
			quest1.text= "Can I help you? \n";
			box.enabled=true;
			timesTalked = 1;
        }
		
		if((Distance() <=interaction) && (timesTalked ==1))
		{
			GetComponent<Animation>().Play("dialog2");
			if(Input.GetKeyDown(KeyCode.Mouse0)){
					quest1.text = "Need a new weapon? \n";
					quest1.text = "Find me some metals and wood. \n";
					quest1.text+= "(O)kay or (N)o, thanks";
					conversation = 1;
	
				}
				if(conversation==1){
					if(Input.GetKeyDown(KeyCode.O)){
						quest1.text = "Bring me the supplies whenever";
						onQuest = 1;
					}
					if(Input.GetKeyDown(KeyCode.N))quest1.text = "Come back if you change your mind";
				}
				
		}
		
		if((onQuest==1) && (timesTalked == 0) && (enemies >= 1))
		{
			GetComponent<Animation>().Play("dialog1");
			box.enabled = true;
			quest1.text = "I need more materials \n";
			quest1.text += "before I can make your weapon.";
			
		}
		
		if((onQuest==1) &&(timesTalked ==0) && (enemies ==0))
		{
			GetComponent<Animation>().Play("dialog2");
			box.enabled = true;
			quest1.text = "Thanks for the work";
			questCompleted = 1;
		}
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			quest1.text = "";
			box.enabled=false;
			timesTalked =0;
			conversation=0;
			GetComponent<Animation>().Play("blacksmith");

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, NPC.position);
    }
}
