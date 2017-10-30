using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        Invoke("Respawning", 10);
    }

    

    void Respawning()
    {
        this.GetComponent<SphereCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
