using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        // Checking if we've collided with the ball
        Ball ball = other.GetComponent<Ball>();
        if (ball)
        {
            ball.Die();
            GameManager.Lives--;
            // Multiplayer settings
            if (gameObject.name == "FirstDF")
                GameManagerMultiplayer.P1Lives--;
            if (gameObject.name == "SecondDF")
                GameManagerMultiplayer.P2Lives--;
        }
    }
}
