using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {



	// Use this for initialization
	void Start () {


	}


	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0))    
			GetComponent<Animation>().Play();

	}

	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Goblins")
		{
            Destroy(col.gameObject);
        }

    }





	public interface ISwordHittable {

		void OnGetHitByAxe(float hitValue);
	}
}