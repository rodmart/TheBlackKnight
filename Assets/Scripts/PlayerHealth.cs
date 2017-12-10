using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	public int enemies;
	public float healthBarLength;
	public int questCompleted1 = 0;
	
	public GameObject QuestGiver;
	void Start () {
	}


	void Update () {
		AddjustCurrentHealth(0);
		if(curHealth <= 0)
			SceneManager.LoadScene("Terrain");
		
		//Application.Quit(); use when exiting game
		questCompleted1 = QuestGiver.GetComponent<Quest1NPC>().questCompleted;
		
		if(questCompleted1==1)
		{
			maxHealth = 200;
		}
	}


	void OnGUI(){
		GUI.Box(new Rect(10, 10, healthBarLength, 20), curHealth + "/" + maxHealth);	
	}


	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;	

		if(curHealth < 0)
			curHealth = 0;
			

		if(curHealth > maxHealth)
			curHealth = maxHealth;

		if(maxHealth < 1)
			maxHealth = 1;

		healthBarLength = (Screen.width / 3) * (curHealth / (float)maxHealth);
	}
}