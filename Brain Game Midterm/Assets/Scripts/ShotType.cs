using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotType : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            this.GetComponent<Text>().color = new Color(0, 200, 0, 255);
        }
    }
}
