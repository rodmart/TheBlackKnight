using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorriedVillagers : MonoBehaviour {

    private float rangeDistance;
	private float interaction;
    private Transform player;
	private int timesTalked = 0;
	public Text textBox;
	public Image box;
	private int onQuest1 =0;
	public int questCompleted1 = 0;
	public GameObject QuestGiver;
	// Use this for initialization
	void Start () {
		rangeDistance=7;
		interaction = 5;
		player = GameObject.FindWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {

		onQuest1 = QuestGiver.GetComponent<Quest1NPC>().onQuest;
		questCompleted1 = QuestGiver.GetComponent<Quest1NPC>().questCompleted;
		
		//start dialogue
        if ((Distance() <= rangeDistance) && (timesTalked == 0) && (onQuest1==0))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I heard some man's daughter was missing \n";
			box.enabled=true;
			timesTalked = 1;
        }
		
		if((Distance() <=interaction) && (timesTalked ==1))
		{
			GetComponent<Animation>().Play("dialog");
			if(Input.GetKeyDown(KeyCode.E)){
					textBox.text = "I'm sure he needs help... \n";
	
				}
				
		}
		
		if((onQuest1==1) && (timesTalked == 0) && (questCompleted1==0))
		{
			GetComponent<Animation>().Play("dialog");
			box.enabled = true;
			textBox.text = "I wonder if the daughter is ok...";
		}
		
		if((onQuest1==1) &&(timesTalked ==0) && (questCompleted1==1))
		{
			GetComponent<Animation>().Play("dialog");
			box.enabled = true;
			textBox.text = "Did you hear?";
			textBox.text += "The man's daughter was saved!";
			questCompleted1 = 1;
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
