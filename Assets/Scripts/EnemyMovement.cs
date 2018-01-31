using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform goalPoint;
    private Rigidbody rb;
    private Text scoreT;
   
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        foreach(Text x in FindObjectsOfType<Text>())
        {
            if(x.name == "Score")
            {
                scoreT = x;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y <= -3)
        {
            scoreT.text = (System.Int32.Parse(scoreT.text) + 1).ToString();
            Destroy(gameObject);
            
        }
        Vector3 dir = goalPoint.position - transform.position;      
        float dist = dir.magnitude;        
        dir = dir.normalized;        
        float move = speed * Time.deltaTime;       
        if (move > dist) move = dist;        
        transform.Translate(dir * move);
    }
}
