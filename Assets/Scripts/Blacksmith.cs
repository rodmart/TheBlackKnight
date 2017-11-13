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
	private int questCollectables;

	

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		AudioSource audio = GetComponent<AudioSource>();
		GameObject[] collectables = GameObject.FindGameObjectsWithTag("collectables");
		questCollectables = collectables.Length;

		
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
			if(Input.GetKeyDown(KeyCode.Mouse0)){
					quest1.text = "Need a new weapon? \n";
					quest1.text+= "(Y)es or (N)o";
					conversation = 1;
					GetComponent<Animation>().Play("dialog1");
	
				}
				
				if(conversation==1){
					if(Input.GetKeyDown(KeyCode.Y)){
						quest1.text = "Bring me the metal and wood.";
						onQuest = 1;
						GetComponent<Animation>().Play("dialog1");
					}
					if(Input.GetKeyDown(KeyCode.N)){
						quest1.text = "Come back if you change your mind";
						GetComponent<Animation>().Play("dialog2");
					}
				}
				
		}
		
		if((onQuest==1) && (timesTalked == 0) && (questCollectables >= 1))
		{
			box.enabled = true;
			quest1.text = "I need more materials \n";
			quest1.text += "before I can make your weapon.";
			
		}
		
		if((onQuest==1) &&(timesTalked ==0) && (questCollectables ==0))
		{
			
			box.enabled = true;
			quest1.text = "Thanks for the work";
			questCompleted = 1;
		}
		
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			GetComponent<Animation>().Play("blacksmith");
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
