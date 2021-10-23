using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingLine : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector3 mousePos;
    Vector3 mouseDirection;
    Camera cam;
    LineRenderer sling;
    

    void Start(){
        sling = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    void Update(){
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = mousePos - gameObject.transform.position;
        mouseDirection.z = 0;
        mouseDirection = mouseDirection.normalized;

        if (Input.GetMouseButtonDown(0)){
            sling.enabled = true;
        }

        if (Input.GetMouseButton(0)){
            startPos = gameObject.transform.position;
            startPos.z = 0;
            sling.SetPosition(0, startPos);
            endPos = mousePos;
            endPos.z = 0;
            float capLength = Mathf.Clamp(Vector2.Distance(startPos, endPos), 0, 3);
            endPos = startPos + (mouseDirection * capLength);
            sling.SetPosition(1, endPos);
        }

        if (Input.GetMouseButtonUp(0)){
            sling.enabled = false;
        }
    }
}
