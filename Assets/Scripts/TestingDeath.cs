using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDeath : MonoBehaviour {

	public Transform NPC;
	public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Distance() <5)
		{
			Destroy(gameObject);
		}
	}
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, NPC.position);
    }
}
