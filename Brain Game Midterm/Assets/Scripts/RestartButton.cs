using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(Restart);
    }

    void Restart(){
        SceneManager.LoadScene( "Scene1");
    }
}
