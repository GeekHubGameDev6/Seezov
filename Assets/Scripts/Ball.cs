using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigbody;
    public float BallForce;
    private GameObject _paddle;
    private bool _isAttached = true;

    void Start()
    {
        _paddle = GameObject.Find("paddleRed");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(!Audio.IsMuted)
            GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {
        // Fire the ball
        if (_isAttached)
	    {
	        BallRigbody.position = _paddle.transform.position + new Vector3(0, 0.27f, 0);
            // Launch with "Space" or Button
	        if (Input.GetButtonDown("Jump"))
	        {
	            LaunchBall();
	        }
	    }
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
            if (!SecondPaddle.IsMultiplayer)
                GameManagerEndless.StartTimer = true;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Paddle paddleScript = _paddle.GetComponent<Paddle>();
        paddleScript.SpawnBall();
        _isAttached = true;
    }
}
