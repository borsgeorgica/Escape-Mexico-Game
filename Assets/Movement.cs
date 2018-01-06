using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float movementSpeed =  Input.GetAxis("Vertical");
        //anim.SetFloat("speed", movementSpeed);
        if (Input.GetKey(KeyCode.RightArrow))
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

    }
}
