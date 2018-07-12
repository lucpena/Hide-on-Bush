using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathFade : MonoBehaviour {

    public CanvasGroup deathCanvas;
    public Transform player;
    public GameObject deathCanvasObject;
    private bool hasCoroutineStarted = false;

    void Update() {
       WaitForDeathScene();
    }

    public void WaitForDeathScene() {
        if (player.tag == "Death" && !hasCoroutineStarted) {
            deathCanvasObject.SetActive(true);
            hasCoroutineStarted = true;
            StartCoroutine(DeathScene());
        }
    }

    public IEnumerator DeathScene() {
        StartCoroutine(FadeCanvasGroup(deathCanvas, deathCanvas.alpha, 1));
        yield return new WaitForSeconds(2.5f);
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float learpTimer = 0.5f) {

        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / learpTimer;


        while (true) {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / learpTimer;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) {
                break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
