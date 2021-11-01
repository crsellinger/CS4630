using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    [Header("Set in Inspector")]
    float projectileSpeed = 40f;
    public GameObject[] projectiles;
    public Transform barrel;
    Vector2 mousePos;


    public Text proj1Text;
    public Text proj2Text;
    public Text proj3Text;

    // Start is called before the first frame update
    void Start()
    {
        proj1Text = GameObject.Find("Canvas/Shot Number 1").GetComponent<Text>();
        proj2Text = GameObject.Find("Canvas/Shot Number 2").GetComponent<Text>();
        proj3Text = GameObject.Find("Canvas/Shot Number 3").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cannon = GameObject.Find("Cannon");
        
        //Cannon rotation
        mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + -90);

        //Fire inputs
        if (Input.GetKeyDown(KeyCode.S)){
            TempFire(projectiles[0]);
            int shotNum = int.Parse(proj1Text.text);
            shotNum -= 1;
            proj1Text.text = shotNum.ToString();
        }

        if (Input.GetKeyDown(KeyCode.D)){
            TempFire(projectiles[1]);
            int shotNum = int.Parse(proj2Text.text);
            shotNum -= 1;
            proj2Text.text = shotNum.ToString();
        }

        if (Input.GetKeyDown(KeyCode.F)){
            TempFire(projectiles[2]);
            int shotNum = int.Parse(proj3Text.text);
            shotNum -= 1;
            proj3Text.text = shotNum.ToString();
        }
    }

    //FIX NOTE: really janky, don't know why, no time
    void TempFire(GameObject projectilePrefab) {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = barrel.transform.position;
        projGO.transform.rotation = barrel.transform.rotation;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.AddForce(barrel.transform.up * projectileSpeed, ForceMode.VelocityChange);
    }
}
