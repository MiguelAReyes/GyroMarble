using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour {

    public Text scoreText;
    public int totalPoints;
    private int pointsCounter;
    public GameObject loseText;
    // Use this for initialization
    void Start () {
        pointsCounter = totalPoints;
        scoreText.text = pointsCounter + "/" + totalPoints;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            pointsCounter -= 1;
            scoreText.text = pointsCounter + "/" + totalPoints;
            if (pointsCounter <= 0)
            {
                loseText.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
