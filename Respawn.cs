using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    private Vector3 startPos;
    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        startRotation = transform.rotation;
	}

    //Detect colision with  trigger

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Death") {
            transform.position = startPos;
            transform.rotation = startRotation;
            GetComponent<Animator>().Play("LOSE00", -1, 0f);
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
        }

        else if (col.tag == "Checkpoint") {
            startPos = col.transform.position;
            startRotation = col.transform.rotation;
            Destroy(col.gameObject);
        } 
    }
}
