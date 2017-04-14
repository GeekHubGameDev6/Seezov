using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour{

    public Rigidbody2D Rigbody;
    public float Speed;
    public GameObject BallPrefab;
    public GameObject ControlButtonOne;
    public GameObject ControlButtonTwo;
    public GameObject LaunchButton;

    void Start ()
    {
        // Spawn new ball
        SpawnBall();
    }

    void Update ()
	{
#if UNITY_ANDROID
        // Android control buttons & accelerometer
        if (Time.timeScale > 0)
        {
            ControlButtonOne.SetActive(true);
            ControlButtonTwo.SetActive(true);
            LaunchButton.SetActive(true);
        }
        if (Time.timeScale > 0 && !SecondPaddle.IsMultiplayer)
	    {
	        // Accelerometer control
	        transform.Translate(Input.acceleration.x/4, 0f, 0f);
	    }
#endif
#if UNITY_STANDALONE_WIN
        // Moving paddle with left and right arrows
        if (Input.GetAxis("Horizontal") < 0)
            MoveLeft();
        if (Input.GetAxis("Horizontal") > 0)
            MoveRight();
        if (Input.GetAxis("Horizontal") == 0)
            Stop();
#endif
        // Restricting paddle
        if (transform.position.x > 2.1f)
            transform.position = new Vector3(2.1f, transform.position.y, transform.position.z);
        if (transform.position.x < -2.1f)
            transform.position = new Vector3(-2.1f, transform.position.y, transform.position.z);   

	}

    public void MoveLeft()
    {
        Rigbody.velocity = new Vector2(-Speed, 0);
    }

    public void MoveRight()
    {
        Rigbody.velocity = new Vector2(Speed, 0);
    }

    public void Stop()
    {
        Rigbody.velocity = Vector2.zero;
    }

    // Realistic collisions
    void OnCollisionEnter2D(Collision2D coll)
    {
        //  If we collided with Power-Up
        if(coll.gameObject.layer == 8)
            GetComponent<AudioSource>().Play();
        foreach (ContactPoint2D contact in coll.contacts)
        {  
            if (contact.otherCollider == GetComponent<CapsuleCollider2D>())
            { 
                float realistic = contact.point.x - transform.position.x;
                contact.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(350*realistic,0));
            }
        }
    }

    public void SpawnBall()
    {
        Instantiate( BallPrefab ,transform.position + new Vector3(0f, 0.27f, 0f),Quaternion.identity);
    }
}
