using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Blacksmith : MonoBehaviour {


    private float rangeDistance;
	private float interaction;
    private Transform player;
	private int timesTalked = 0;
	private int conversation = 0;
	public Text quest1;
	public Image box;
	public int onQuest =0;
	public int questCompleted = 0;
	private int questCollectables;

	

    // Use this for initialization
    void Start () {
		rangeDistance=7;
		interaction = 5;
		player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
		GameObject[] collectables = GameObject.FindGameObjectsWithTag("collectables");
		questCollectables = collectables.Length;

		
		//start dialogue
        if ((Distance() <= rangeDistance) && (timesTalked == 0) )
        {
			AudioSource audio = GetComponent<AudioSource>();
			quest1.text = "Hello\n";
			box.enabled=true;
			GetComponent<Animation>().Play("dialog1");
			
			if(Input.GetKeyDown(KeyCode.E)){
				timesTalked = 1;
				audio.Play();
				}
        }
		
		if((Distance() <=interaction) && (timesTalked ==1)&& (onQuest==0))
		{
			if(Input.GetKeyDown(KeyCode.E)){
					quest1.text = "Need a sharper weapon? \n";
					quest1.text+= "(Y)es or (N)o";
					conversation = 1;
					GetComponent<Animation>().Play("dialog1");
	
				}
				
				if(conversation==1){
					if(Input.GetKeyDown(KeyCode.Y)){
						quest1.text = "Bring me some rusty swords.";
						onQuest = 1;
						GetComponent<Animation>().Play("dialog1");
					}
					if(Input.GetKeyDown(KeyCode.N)){
						quest1.text = "Come back if you change your mind";
						GetComponent<Animation>().Play("dialog2");
					}
				}
				
		}
		
		if((onQuest==1) && (timesTalked == 1) && (questCollectables >= 1))
		{
			box.enabled = true;
			quest1.text = "I need " + questCollectables +" rusty sword(s) \n";
			quest1.text += "before I can make your weapon.";
			
		}
		
		if((onQuest==1) &&(timesTalked ==1) && (questCollectables ==0))
		{
			
			box.enabled = true;
			quest1.text = "Enjoy your new blade";
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

        return Vector3.Distance(player.position, this.transform.position);
    }
}
