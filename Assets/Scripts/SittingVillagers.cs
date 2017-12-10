using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SittingVillagers : MonoBehaviour {
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
			GetComponent<Animation>().Play("sitting dialog");
			textBox.text= "Guess we can only sit and watch..\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 2))
        {
			GetComponent<Animation>().Play("sitting dialog");
			textBox.text= "This town may be too crazy for me.\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 3))
        {
			GetComponent<Animation>().Play("sitting dialog");
			textBox.text= "How did this happen?\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 4))
        {
			GetComponent<Animation>().Play("sitting dialog");
			textBox.text= "Might as well see what happens\n";
			box.enabled=true;
        }
		

		
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			textBox.text = "";
			box.enabled=false;
			GetComponent<Animation>().Play("sitting idle");
			conversation = Random.Range(1,5);

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}
