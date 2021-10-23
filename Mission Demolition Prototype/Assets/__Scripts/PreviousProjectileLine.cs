using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousProjectileLine : MonoBehaviour
{
    ProjectileLine projectileLine;
    LineRenderer line1;
    List<Vector3> previousPoints = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        line1 = GameObject.Find("ProjectileLine").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (line1){
        //     line1.positionCount = previousPoints.Count;
        //     print(previousPoints.Count);
        //     //line1.SetPositions(previousPoints.ToArray());
        // }
    }
}
