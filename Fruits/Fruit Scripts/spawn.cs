using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public GameObject fruit;
    int spawnNum = 3;



    void Spawn()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            Vector3 fruitPos = new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f),
                                            this.transform.position.y + Random.Range(0.0f, 2.0f),
                                            this.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(fruit, fruitPos, Quaternion.identity);
        }
    }
    // Use this for initialization
    void Start()
    {
        Spawn();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
