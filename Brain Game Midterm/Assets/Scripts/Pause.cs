using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        Pausepls();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if (isPaused){
                Resume();
            }
            else{
                Pausepls();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        TimerController.instance.BeginTimer();
    }

    public void Pausepls() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        TimerController.instance.EndTimer();
    }
}
