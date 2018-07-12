using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeOutFade : MonoBehaviour {

    public CanvasGroup timeOutCanvas;
    public GameObject timeOutCanvasObject;
    public Player player;
    private TempoRestante tempoRestante;
    private bool hasCoroutineStarted = false;

    void Update() {
        WaitForTimeOut();
    }

    void Start() {
        tempoRestante = GameObject.Find("Time").GetComponent<TempoRestante>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void WaitForTimeOut() {
        if ((tempoRestante.remaining <= 0) && !hasCoroutineStarted) {
            timeOutCanvasObject.SetActive(true);
            hasCoroutineStarted = true;
            player.timedOut = true;
            StartCoroutine(TimeOutScene());
        }
    }

    public IEnumerator TimeOutScene() {
        StartCoroutine(FadeCanvasGroup(timeOutCanvas, timeOutCanvas.alpha, 1));
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
