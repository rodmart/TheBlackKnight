using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Villager : MonoBehaviour {

    public float rangeDistance;
    public Transform villager;
    public Transform player;
	private int playOnce = 0;
	public Text quest1;
	

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		Canvas quest = GetComponent<Canvas>();
		AudioSource audio = GetComponent<AudioSource>();

        if ((Distance() <= rangeDistance) && (playOnce == 0))
        {
            audio.Play();
			playOnce=1;
			setQuest();
        }
		
		if ((Distance() > rangeDistance) && (playOnce == 1))
        {
			playOnce=0;
			deleteQuest();
        }



    }
	
	private void setQuest(){
		quest1.text="I need your help!";
	}
	
	private void deleteQuest(){
		quest1.text = "";
	}
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, villager.position);
    }
}
