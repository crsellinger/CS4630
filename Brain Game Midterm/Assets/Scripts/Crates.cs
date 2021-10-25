using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float      speed = 10f;      // The speed in m/s
    private BoundsCheck bndCheck;

    void Awake() {                                                           
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos {                                                     
        get {
            return( this.transform.position );
        }
        set {
            this.transform.position = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if ( bndCheck != null && bndCheck.offDown ) {                    
            Destroy( gameObject );
        }
    }

    public virtual void Move() {                                             
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
