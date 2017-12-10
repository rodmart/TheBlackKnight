using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomVillagers : MonoBehaviour {
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
			textBox.text= "If I make it, I need to move out of this town.\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 2))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "This town may be too crazy for me.\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 3))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "How did this happen?\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (conversation == 4))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "What did I do to deserve this?\n";
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
