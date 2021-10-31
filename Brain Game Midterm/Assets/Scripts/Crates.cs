using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            int crateNum = int.Parse(transform.GetChild(0).GetComponent<TMP_Text>().text);
            int score = int.Parse(scoreGT.text);
            score -= crateNum;
            scoreGT.text = score.ToString();
        }
    }

    public virtual void Move() {                                             
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter( Collision coll ) {
        GameObject otherGO = coll.gameObject;

        //Projectile 1, -1 when hit crate
        if ( otherGO.tag == "Projectile1" ) {
            int crateNum = int.Parse(transform.GetChild(0).GetComponent<TMP_Text>().text);
            crateNum -= 1;
            transform.GetChild(0).GetComponent<TMP_Text>().text = crateNum.ToString();
            
            //scoring part
            if (crateNum <= 0){
                Destroy( gameObject );
                if (crateNum < 0){
                    int score = int.Parse(scoreGT.text);
                    score -= 1;
                    scoreGT.text = score.ToString();
                }
                else{
                    int score = int.Parse(scoreGT.text);
                    score += 1;
                    scoreGT.text = score.ToString();
                }
            }

            Destroy( otherGO );
        }
        
        //Projectile 2, -2 when hit crate
        if (otherGO.tag == "Projectile2"){
            int crateNum = int.Parse(transform.GetChild(0).GetComponent<TMP_Text>().text);
            crateNum -= 2;
            transform.GetChild(0).GetComponent<TMP_Text>().text = crateNum.ToString();
            
            //scoring part
            if (crateNum <= 0){
                Destroy( gameObject );
                if (crateNum < 0){
                    int score = int.Parse(scoreGT.text);
                    score -= 2;
                    scoreGT.text = score.ToString();
                }
                else{
                    int score = int.Parse(scoreGT.text);
                    score += 2;
                    scoreGT.text = score.ToString();
                }
            }

            Destroy( otherGO );
        }

        //Projectile 3, -3 when hit crate
        if (otherGO.tag == "Projectile3"){
            int crateNum = int.Parse(transform.GetChild(0).GetComponent<TMP_Text>().text);
            crateNum -= 3;
            transform.GetChild(0).GetComponent<TMP_Text>().text = crateNum.ToString();
            
            //scoring part
            if (crateNum <= 0){
                Destroy( gameObject );
                if (crateNum < 0){
                    int score = int.Parse(scoreGT.text);
                    score -= 3;
                    scoreGT.text = score.ToString();
                }
                else{
                    int score = int.Parse(scoreGT.text);
                    score += 3;
                    scoreGT.text = score.ToString();
                }
            }

            Destroy( otherGO );
        }
    }
}