using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPaddle : MonoBehaviour
{

    public static bool IsMultiplayer = true;

    public Rigidbody2D Rigbody;
    public float Speed;
    public GameObject ControlButtonOne;
    public GameObject ControlButtonTwo;

    void Update()
    {
#if UNITY_ANDROID
        if (Time.timeScale > 0)
        {
            ControlButtonOne.SetActive(true);
            ControlButtonTwo.SetActive(true);
        }
#endif
#if UNITY_STANDALONE_WIN
        // Moving paddle
        if (Input.GetKey(KeyCode.Z))
            MoveLeft();
        if (Input.GetKey(KeyCode.X))
            MoveRight();
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.X))
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
        foreach (ContactPoint2D contact in coll.contacts)
        {
            if (contact.otherCollider == GetComponent<CapsuleCollider2D>())
            {
                float realistic = contact.point.x - transform.position.x;
                contact.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(350 * realistic, 0));
            }
        }
    }
}
