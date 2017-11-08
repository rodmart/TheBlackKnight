using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Box_Facing_Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform.position, Vector3.up);
		
	}
}
