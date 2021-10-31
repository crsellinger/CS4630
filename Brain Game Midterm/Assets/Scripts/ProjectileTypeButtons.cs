using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileTypeButtons : MonoBehaviour
{
    GameObject m;
    GameObject n;
    GameObject o;

    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("Canvas/ProjectileType1");
        n = GameObject.Find("Canvas/ProjectileType2");
        o = GameObject.Find("Canvas/ProjectileType3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S)){
            m.GetComponent<Text>().color = Color.green;
        }
        else{
            m.GetComponent<Text>().color = Color.white;
        }

        if (Input.GetKey(KeyCode.D)){
            n.GetComponent<Text>().color = Color.green;
        }
        else{
            n.GetComponent<Text>().color = Color.white;
        }

        if (Input.GetKey(KeyCode.F)){
            o.GetComponent<Text>().color = Color.green;
        }
        else{
            o.GetComponent<Text>().color = Color.white;
        }
    }
}
