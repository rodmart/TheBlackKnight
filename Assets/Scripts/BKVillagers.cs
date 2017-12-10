using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BKVillagers : MonoBehaviour {

private float rangeDistance;
    private Transform player;
	private int conversation = 0;
	public Text textBox;
	public Image box;

	// Use this for initialization
	void Start () {
		rangeDistance=7;
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//start dialogue
        if ((Distance() <= rangeDistance) && (conversation == 1))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "The black knight is over in that grey house..\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 2))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I wouldn't approach the black knight unless you wanted to fight him.\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 3))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "If only someone was brave enough to fight him...\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 4))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "The black knight already killed the previous owner of the grey house\n";
			box.enabled=true;
        }
		

		
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			textBox.text = "";
			box.enabled=false;
			GetComponent<Animation>().Play("idle");
			conversation = Random.Range(1,5);

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}
