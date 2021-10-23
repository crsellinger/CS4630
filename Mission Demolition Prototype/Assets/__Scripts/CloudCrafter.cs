using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int numClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPosMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1f;
    public float cloudScaleMax = 3f;
    public float cloudSpeedMult = 3.5f;
    private GameObject[] cloudInstances;

    void Awake(){
        cloudInstances = new GameObject[numClouds];
        GameObject anchor = GameObject.Find("CloudAnchor");
        GameObject cloud;

        for (int i = 0; i < numClouds; i++){
            cloud = Instantiate<GameObject>(cloudPrefab);

            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            //cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);

            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            //cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            //smaller clouds should be further away
            //cPos.z = 100 - 90 * scaleU;

            //For parallax scolling
            //Larger clouds are higher and farther away
            if (cloud.transform.localScale.x < 1.75){
            //smaller clouds should be lower (for parallax)
                cPos.y = (30 * scaleU) - 5;
                cPos.z = Random.Range(1, 25);
            }
            else if(cloud.transform.localScale.x < 2.25){
                cPos.y = 30 + (60 * scaleU) - 5;
                cPos.z = Random.Range(25, 50);
            }
            else {
                cPos.y = 60 + (105 * scaleU) - 5;
                cPos.z = Random.Range(50, 100);
            }

            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            cloud.transform.SetParent(anchor.transform);
            cloudInstances[i] = cloud;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        foreach( GameObject cloud in cloudInstances){
            float scaleVal = cloud.transform.localScale.x;
            //print(scaleVal);
            Vector3 cPos = cloud.transform.position;

            //move larger clouds faster for parallax
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;

            if (cPos.x <= cloudPosMin.x){
                cPos.x = cloudPosMax.x;
            }

            cloud.transform.position = cPos;
        }
    }
}
