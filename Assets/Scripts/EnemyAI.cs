using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {
	private Transform player;
	private GameObject target;
	private int moveSpeed;
	private int rotationSpeed;
	private int maxdistance;
	private int mindistance;
	public GameObject mob;
	private Transform myTransform;
    public GameObject itemToSpawn;

    private int maxHealth = 100;
	private int curHealth = 100;
	private bool alive = true;
	
	public Text healthdisplay;
	public Image box;
	
	private float attackTime;
	private float coolDown;

	void Start(){
		myTransform = transform;
		attackTime = 2.0f;
		coolDown = 2.0f;
		player = GameObject.FindWithTag("Player").transform;
		target = GameObject.FindWithTag("Player");
		moveSpeed=3;
		rotationSpeed = 10;
		maxdistance = 10;
		mindistance = 2;
		maxHealth = 100;
		curHealth = 100;
	}

	void OnTriggerEnter(Collider col){
			if (col.gameObject.tag == "sword"){
				curHealth -= 20;
			}
			
			if (col.gameObject.tag == "swordUpgrade"){
				curHealth -= 40;
			}
    }


	void Update () {
		
		AddjustCurrentHealth(0);
		
		if((curHealth <= 0) && (alive))
		{
			alive = false;
			GetComponent<Animation>().Play("death1");
			Destroy(mob,3);
            GameObject obj = Instantiate(itemToSpawn, transform.position + new Vector3(1,1), transform.rotation);
            obj.tag = "potion1";
            healthdisplay.text = curHealth + "/" + maxHealth;
			
		}
		
		if(attackTime > 0){attackTime -= Time.deltaTime;}
		if(attackTime < 1){attackTime = 0;}
		if((attackTime == 0)&&(alive)) {
			Attack();
			attackTime = coolDown;
			 
		}
		
		
		if((distance() > maxdistance)&& (alive))
		{
			GetComponent<Animation>().Play("idle basic");
			box.enabled = false;
			healthdisplay.text = "";
		}
		

		if((distance() < maxdistance)  && (distance() > mindistance)&&(alive)){
			//Move towards player
			GetComponent<Animation>().Play("run");
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			transform.LookAt(player);
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
			box.enabled = true;
			healthdisplay.text = curHealth + "/" + maxHealth;
		}
		

		myTransform.position = myTransform.position;
		
	}
	


	
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;	

		if(curHealth < 0)curHealth = 0;
		if(curHealth > maxHealth)curHealth = maxHealth;
		if(maxHealth < 1)maxHealth = 1;
	}
	

	

	 private void Attack() 
	 {
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);

		if(distance() < 2.5f) {
			if(direction > 0) { 
				GetComponent<Animation>().Play("attack1");
				PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");
				eh.AddjustCurrentHealth(-10);
			}
		}
	}
	
	private float distance()
	{
		float distance = Vector3.Distance(target.transform.position, transform.position);
		return distance;
	}

}