using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Baker : MonoBehaviour {

    public float rangeDistance;
    public Transform baker;
	public float interaction;
    public Transform player;
	private int timesTalked = 0;
	private int conversation = 0;
	public Text quest1;
	public Image box;

	

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
		AudioSource audio = GetComponent<AudioSource>();
		
		//start dialogue
        if ((Distance() <= rangeDistance) && (timesTalked == 0))
        {
            audio.Play();
			timesTalked=1;
			quest1.text= "Bread for sale! \n";
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
						eh.AddjustCurrentHealth(100);
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

        return Vector3.Distance(player.position, baker.position);
    }
}
