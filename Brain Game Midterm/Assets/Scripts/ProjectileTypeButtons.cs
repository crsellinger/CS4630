using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileTypeButtons : MonoBehaviour
{
    GameObject projType1;
    GameObject projType2;
    GameObject projType3;

    GameObject type1Num;
    GameObject type2Num;
    GameObject type3Num;

    // Start is called before the first frame update
    void Start()
    {
        projType1 = GameObject.Find("Canvas/ProjectileType1");
        projType2 = GameObject.Find("Canvas/ProjectileType2");
        projType3 = GameObject.Find("Canvas/ProjectileType3");

        type1Num = GameObject.Find("Canvas/Shot Number 1");
        type2Num = GameObject.Find("Canvas/Shot Number 2");
        type3Num = GameObject.Find("Canvas/Shot Number 3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S)){
            projType1.GetComponent<Text>().color = Color.green;
            type1Num.GetComponent<Text>().color = Color.green;
        }
        else{
            projType1.GetComponent<Text>().color = Color.white;
            type1Num.GetComponent<Text>().color = Color.white;
        }

        if (Input.GetKey(KeyCode.D)){
            projType2.GetComponent<Text>().color = Color.green;
            type2Num.GetComponent<Text>().color = Color.green;
        }
        else{
            projType2.GetComponent<Text>().color = Color.white;
            type2Num.GetComponent<Text>().color = Color.white;
        }

        if (Input.GetKey(KeyCode.F)){
            projType3.GetComponent<Text>().color = Color.green;
            type3Num.GetComponent<Text>().color = Color.green;
        }
        else{
            projType3.GetComponent<Text>().color = Color.white;
            type3Num.GetComponent<Text>().color = Color.white;
        }
    }
}
