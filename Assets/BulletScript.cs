using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    // Use this for initialization
    void onTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Trump"))
        {
            col.gameObject.SetActive(false);
            //Destroy(col.gameObject);
            this.gameObject.SetActive(false);
            //life--;

            //Trump dies
        }
    }

}
