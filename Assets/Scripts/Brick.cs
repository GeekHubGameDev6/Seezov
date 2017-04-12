using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int BrickValue = 10;
    public int HitPoints = 1;


    // Use this for initialization
    void Start ()
    {
        GameManager.NumberOfBricks++;
        GameManagerEndless.NumberOfBricks++;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        HitPoints--;
        if (HitPoints == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        AddPoints(BrickValue);
        GameManager.NumberOfBricks--;
        GameManagerEndless.NumberOfBricks--;
    }
    public void AddPoints(int point)
    {
        GameManager.Score += point;
        GameManagerEndless.Score += point;
    }
}
