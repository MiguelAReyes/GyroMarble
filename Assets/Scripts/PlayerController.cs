using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
    public GameObject plane;
	private Rigidbody rb;
    public int collisionSpeed;
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    public GameObject loseText;
    

    void Start ()
	{
		rb = GetComponent<Rigidbody>();        
        Input.gyro.enabled = true;
        loseText.SetActive(false);
    }
	void FixedUpdate ()
	{
        if(Input.GetButtonDown("Jump"))
        {
            
            SceneManager.LoadScene("testing1");
        }
        if(transform.position.y <= -3)
        {
            loseText.SetActive(true);
            Time.timeScale = 0;
        }
        float moveHorizontal;
        float moveVertical;
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            //float moveHorizontal = Input.gyro.rotationRate.x;
            // float moveVertical = Input.gyro.rotationRate.y;

            
        }
        else
        {
             moveHorizontal = Input.gyro.rotationRate.x;
             moveVertical = Input.gyro.rotationRate.y;
            
        }
       Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       rb.AddForce(movement * speed);

     /*   float tiltAroundZ = moveHorizontal * tiltAngle;
        float tiltAroundX = moveVertical * tiltAngle;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        plane.transform.rotation = Quaternion.Slerp(plane.transform.rotation, target, Time.deltaTime * smooth);
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            Quaternion target2 = Quaternion.Euler(0, 0, 0);
            plane.transform.rotation = Quaternion.Slerp(plane.transform.rotation, target2, Time.deltaTime * smooth);
        }*/

        


    }
    private void OnCollisionEnter(Collision collision)
    {
        hitting(collision.collider);
    }
    void hitting(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody en = other.gameObject.GetComponent<Rigidbody>();
                en.AddForce(rb.velocity*collisionSpeed);
        }
    }
   
}
