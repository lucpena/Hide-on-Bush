using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Slider healthBar;
    public bool timedOut = false;

    private Animator anim;
    private bool isDead = false;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        CheckDeath();
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Weapon") {
            Hitted();
        }

        if (col.tag == "Collectible") {
            healthBar.value += 5;
        }

    }

    void CheckDeath() {
        if (healthBar.value <= 1 && !isDead) {
            Dead();
        }
    }

    void Hitted() {
        if (!timedOut) {
            print("HIT");
            healthBar.value -= 20;
            anim.SetTrigger("Hit"); 
        }
    }

    void Dead() {
        print("DEAD");
        anim.SetTrigger("Death");
        anim.ResetTrigger("Hit");
        gameObject.tag = "Death";
        Time.timeScale = 0.2f;
        isDead = true;
    }
}
