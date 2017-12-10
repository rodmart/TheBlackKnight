using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public int questCompleted1 = 0;
	public GameObject QuestGiver;

	// Use this for initialization
	void Start () {
	transform.gameObject.tag = "sword"; 
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0))    
			GetComponent<Animation>().Play();
		
		questCompleted1 = QuestGiver.GetComponent<Blacksmith>().questCompleted;

		
		if(questCompleted1 == 1)
		{
			transform.gameObject.tag = "swordUpgrade"; 
		}

	}

	public interface ISwordHittable {

		void OnGetHitByAxe(float hitValue);
	}
}