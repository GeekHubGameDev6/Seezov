using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject Paddle;


    // Use this for initialization
    void Start()
    {
        Paddle = GameObject.Find("paddleRed");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Activate();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void Activate()
    {
        switch (gameObject.name)
        {
            case "PowerUpRed(Clone)":
                GameManager.Lives++;
                Destroy(gameObject);
                break;
            case "PowerUpBlack(Clone)":
                GameManager.Lives--;
                Destroy(gameObject);
                break;
            case "PowerUpGold(Clone)":
                GameManager.Score += 50;
                GameManagerEndless.Score += 50;
                Destroy(gameObject);
                break;
            case "PowerUpBlue(Clone)":
                StartCoroutine(PaddleScale());
                break;
        }
    }

    IEnumerator PaddleScale()
    {
        Paddle.transform.localScale += new Vector3(0.5F, 0, 0);
        Debug.Log("FIRST");
        yield return new WaitForSeconds(5);
        Paddle.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject);
    }

}
