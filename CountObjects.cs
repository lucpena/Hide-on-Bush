using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountObjects : MonoBehaviour {

    public GameObject objUI;

    // Use this for initialization
    void Start() {
        objUI = GameObject.Find("ObjectNum");
    }

    // Update is called once per frame
    void Update() {

        int boxes = BoxCollect.objectsHud;

        objUI.GetComponent<Text>().text = boxes.ToString();
    }
}
