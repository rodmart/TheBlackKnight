using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CouplesFemale : MonoBehaviour {

private float rangeDistance;
    private Transform player;
	public Text textBox;
	public Image box;
	public int matching;
	public GameObject male;

	// Use this for initialization
	void Start () {
		rangeDistance=7;
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		matching = male.GetComponent<CouplesMale>().conversation;
		//start dialogue
        if ((Distance() <= rangeDistance) && (matching == 1))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "You know, lots of crazy people in town.\n";
			box.enabled=true;
        }

		if ((Distance() <= rangeDistance) && (matching == 2))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I don't know, he seems like a mad man.\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (matching == 3))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I heard someone's daughter went missing...\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (matching == 4))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "I think the black knight might kill us before they arrive..\n";
			box.enabled=true;
        }
		
		if ((Distance() <= rangeDistance) && (matching == 5))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "Still doesn't mean he should be doing this.\n";
			box.enabled=true;
        }

		if ((Distance() <= rangeDistance) && (matching == 6))
        {
			GetComponent<Animation>().Play("dialog");
			textBox.text= "After all this is over, we should vacation..\n";
			box.enabled=true;
        }		
		
		//leaving dialogue
		if (Distance() > rangeDistance)
        {
			textBox.text = "";
			box.enabled=false;
			GetComponent<Animation>().Play("idle");

        }


    }
	
	
	private float Distance()
    {

        return Vector3.Distance(player.position, this.transform.position);
    }
}

