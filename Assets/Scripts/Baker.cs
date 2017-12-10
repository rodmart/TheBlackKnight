using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Baker : MonoBehaviour {

    private float rangeDistance;
	private float interaction;
    private Transform player;
	private int timesTalked = 0;
	private int conversation = 0;
	public Text quest1;
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
			timesTalked=1;
			quest1.text= "Fresh meals! \n";
			quest1.text+= "Get it while it's hot!";
			box.enabled=true;
        }
		
		//interaction
		if ((Distance() <= rangeDistance) && (timesTalked == 1))
        {
			if(Distance() <= interaction){

				box.enabled=true;
				if(Input.GetKeyDown(KeyCode.E)){
					quest1.text = "Want some food? \n";
					quest1.text+= "(Y)es or (N)o";
					conversation = 1;
	
				}
				
				if(conversation==1){
					if(Input.GetKeyDown(KeyCode.Y))
					{
						quest1.text = "Hope that heals you up!";
						PlayerHealth eh = (PlayerHealth)player.GetComponent("PlayerHealth");
						eh.AddjustCurrentHealth(200);
					}
					if(Input.GetKeyDown(KeyCode.N))quest1.text = "Take care!";
				}
				
			
				
			}
		}
		
		//leaving dialogue
		if ((Distance() > rangeDistance) && (timesTalked == 1))
        {
			timesTalked=0;
			conversation=0;
			quest1.text = "";
			box.enabled=false;

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}
