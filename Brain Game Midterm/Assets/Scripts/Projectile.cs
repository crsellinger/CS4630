using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck     bndCheck;

    void Awake () {
        bndCheck = GetComponent<BoundsCheck>();
    }
    void Update () {
        if (bndCheck.offUp || bndCheck.offLeft || bndCheck.offRight || bndCheck.offDown) {
            Destroy( gameObject );
        }
    }
}