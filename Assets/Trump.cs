using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trump : MonoBehaviour {
    int life = 3;
	// Use this for initialization
	void Start () {
		
	}

    void onTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Bullet"))
        {
            col.gameObject.SetActive(false);
            life--;
            if(life<=0)
            {

            }
                //Trump dies
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
