using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour {
	public Transform target;
	public GameObject target1;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxdistance;
	public int health;

	private Transform myTransform;

	void Awake(){
		myTransform = transform;
	}


	void Start () {
		
		target = target1.transform;

		maxdistance = 2;
	}


	void Update () {
		Debug.DrawLine(target.position, myTransform.position, Color.red); 


		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

		if(Vector3.Distance(target.position, myTransform.position) > maxdistance){
			//Move towards target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

		}
	}
	



}