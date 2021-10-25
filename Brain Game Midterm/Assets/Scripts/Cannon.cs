using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Set in Inspector")]
    float projectileSpeed = 40f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cannon = GameObject.Find("Cannon");

        //Need mouse speed for z angle
        if (Input.GetAxis("Mouse X") < 0){
            cannon.transform.Rotate(new Vector3(0,0,1), Space.Self);
        }
        else if (Input.GetAxis("Mouse X") > 0){
            cannon.transform.Rotate(new Vector3(0,0,-1), Space.Self);
        }

        //FIX NOTE: currently comes out of cannon base
        //Need to make it come out of barrel
        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            TempFire();
        }
    }

    void TempFire() {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * projectileSpeed;
    }
}
