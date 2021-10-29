using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crates : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float      speed = 10f;      // The speed in m/s
    private BoundsCheck bndCheck;
    public Text scoreGT;

    void Start() {
        scoreGT = GameObject.Find("Canvas/Score Count").GetComponent<Text>();
    }

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

    void OnCollisionEnter( Collision coll ) {
      GameObject otherGO = coll.gameObject;
      if ( otherGO.tag == "Projectile" ) {
        Destroy( otherGO );        // Destroy the Projectile
        Destroy( gameObject );     // Destroy this Enemy GameObject

        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();

        } else {
            print( "Enemy hit by non-ProjectileHero: " + otherGO.name );
        }
    }
}