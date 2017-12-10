using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSwords : MonoBehaviour {
	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Distance() < 1.0f)
		{
			Destroy(gameObject);
		}
	}
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}
