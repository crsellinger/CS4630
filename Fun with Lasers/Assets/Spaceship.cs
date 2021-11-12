using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    LineRenderer line;
    GameObject point;
    Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        point = transform.Find("point").gameObject;
        line = point.GetComponent<LineRenderer>();
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            line.enabled = true;

            Ray ray = new Ray(point.transform.position, transform.up);

            RaycastHit hit;

            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hit, 10))
            {
                line.SetPosition(1, hit.point); //ray is cast from point to collider
                ShowDamage(hit.collider.gameObject);    //hit allows only collided objects to turn red
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(10)); //ray is cast to defined distance
            }
        }
        else
        {
            line.enabled = false;
        }
    }

    void ShowDamage(GameObject go)
    {
        mats = Utils.GetAllMaterials(go);
        foreach(Material m in mats)
        {
            m.color = Color.red;
        }
    }
}
