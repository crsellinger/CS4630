using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;                                // A singleton for Main
    static public int finalScore;

    [Header("Set in Inspector")]
    public GameObject[]      level1_Enemies;              // Array of Enemy prefabs
    public GameObject[]      level2_Enemies;
    public GameObject[]      level3_Enemies;
    public float             enemySpawnPerSecond = 0.5f; // # Enemies/second
    public float             enemyDefaultPadding = 1.5f; // Padding for position

    private BoundsCheck      bndCheck;

    public Text levelText;

    void Awake() {
        S = this;
        // Set bndCheck to reference the BoundsCheck component on this GameObject
        bndCheck = GetComponent<BoundsCheck>();

        levelText = GameObject.Find("Canvas/Level Count").GetComponent<Text>();

        // Invoke SpawnEnemy() once (in 2 seconds, based on default values)
        Invoke( "FirstLevelSpawnEnemy", 1f/enemySpawnPerSecond );
    }

    void Update() {
        if (TimerController.instance.timeCounter.text.ToString() == "Time: 01:00.00"){
            TimerController.instance.EndTimer();
            finalScore = int.Parse(GameObject.Find("Canvas/Score Count").GetComponent<Text>().text);
            SceneManager.LoadScene( "EndScene");
            //Restart();
        }

        if (int.Parse(levelText.text) >= 5){
            //reset level to new level
        }
        // if (int.Parse(levelText.text) >= 10){
        //     levelText.text = "Level 3";
        //     SpawnEnemy(level3_Enemies);
        // }
        // else if (int.Parse(levelText.text) >= 5){
        //     levelText.text = "Level 2";
        //     SpawnEnemy(level2_Enemies);
        // }
        // else{
        //     SpawnEnemy(level1_Enemies);
        // }
    }

    public void FirstLevelSpawnEnemy() {
        // Pick a random Enemy prefab to instantiate
        int ndx = Random.Range(0, level1_Enemies.Length);                     // b
        GameObject go = Instantiate<GameObject>( level3_Enemies[ ndx ] );     // c

        // Position the Enemy above the screen with a random x position
        float enemyPadding = enemyDefaultPadding;                            // d
        if (go.GetComponent<BoundsCheck>() != null) {                        // e
            enemyPadding = Mathf.Abs( go.GetComponent<BoundsCheck>().radius );
        }

        // Set the initial position for the spawned Enemy                    // f
        Vector3 pos = Vector3.zero;              
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax =  bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range( xMin, xMax );
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        // Invoke SpawnEnemy() again
        Invoke( "FirstLevelSpawnEnemy", 1f/enemySpawnPerSecond );                      // g
    }

    public void Restart() {
        // Reload _Scene_0 to restart the game
        SceneManager.LoadScene( "Scene1");
    }
}
