using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TempoRestante: MonoBehaviour {

    public Text timerText;
    public float remaining;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update () {
        remaining -= Time.deltaTime;
        timerText.text = remaining.ToString("f0");

        if (remaining <= 0) {
            remaining = 0;
            Time.timeScale = 0.2f;
        }
	}
}
