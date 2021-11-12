using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolation : MonoBehaviour
{
    public Transform p1, p2;
    public Vector3 p1Pos, p2Pos, bPos;
    float u;

    // Start is called before the first frame update
    void Start()
    {
        //positions of spheres
        p1Pos = p1.position;
        p2Pos = p2.position;
    }

    // Update is called once per frame
    void Update()
    {
        //interpolation, must be done in update function
        u += .001f;
        bPos = (1 - u) * p1Pos + u * p2Pos;

        this.transform.position = bPos;
    }
}
