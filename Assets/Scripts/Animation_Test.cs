using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animation>().Play();
	}
}
