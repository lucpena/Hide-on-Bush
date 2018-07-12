using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasPoints : MonoBehaviour {

    private TextMeshProUGUI myText;

    void Start() {
        myText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        myText.text = "You got " + BoxCollect.objectsHud.ToString() +" points!";
    }
}