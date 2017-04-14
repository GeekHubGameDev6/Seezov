using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameObject _paddle;
    private bool _isAttached = true;

    public Rigidbody2D BallRigbody;
    public float BallForce;
    
    public AudioSource LastHit;
    public AudioSource NormalHit;
    public AudioSource WallHit;

    void Start()
    {
        _paddle = GameObject.Find("paddleRed");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Figuring out what sound to play
        if (coll.gameObject.tag == "Brick")
            if(coll.gameObject.GetComponent<Brick>().HitPoints == 0)
                LastHit.Play();
            else
                NormalHit.Play();
        if (coll.gameObject.tag == "Wall")
            WallHit.Play();

    }

    void Update () {
        // Fire the ball
        if (_isAttached)
	    {
            // Keep the ball with the paddle
	        BallRigbody.position = _paddle.transform.position + new Vector3(0, 0.27f, 0);
            // Launch with "Space"
	        if (Input.GetButtonDown("Jump"))
	        {
	            LaunchBall();
	        }
	    }
        // Destroy ball is level is passed
        if ((GameManagerEndless.NumberOfBricks == 0 || GameManager.NumberOfBricks == 0) && !SecondPaddle.IsMultiplayer)
            Die();
    }

    public void LaunchBall()
    {
        if (_isAttached)
        {
            BallRigbody.bodyType = RigidbodyType2D.Dynamic;
            BallRigbody.AddForce(new Vector2(BallForce * Input.GetAxis("Horizontal"), BallForce));
            _isAttached = false;
            // Start endless game timer
            if (!SecondPaddle.IsMultiplayer)
                GameManagerEndless.StartTimer = true;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        // Reattach the ball
        _paddle.GetComponent<Paddle>().SpawnBall();
        _isAttached = true;
    }
}
