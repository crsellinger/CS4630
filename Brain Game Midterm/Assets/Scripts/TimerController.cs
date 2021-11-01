using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Time 1:00.00";
        timerGoing = false;
        elapsedTime = 0f;
    }

    public void BeginTimer(){
        timerGoing = true;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer(){
        timerGoing = false;
    }

    private IEnumerator UpdateTimer(){
        while (timerGoing){
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
