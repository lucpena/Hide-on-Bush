using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCchase : MonoBehaviour {

    public Transform player;
    public AudioClip SoundToPlay;
    public Transform head;

    Animator anim;

    bool pursuing = false;
    bool AlreadyPlayed = false;

    AudioSource roar;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        roar = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.up);

        if (Vector3.Distance(player.position, transform.position) < 14 && (angle < 40 || pursuing) && player.tag == "Player") {

            pursuing = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isIdle", false);

            if (!AlreadyPlayed) {
                roar.PlayOneShot(SoundToPlay);
            }

            AlreadyPlayed = true;

            if (direction.magnitude > 1.6f) {
                transform.Translate(0,0,0.058f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isIdle", false);
            }
            else {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);

            }

        }
        else {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            AlreadyPlayed = false;
            pursuing = false;
        }
    }
}
