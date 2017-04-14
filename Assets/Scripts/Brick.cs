using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject[] PowerUpPrefabs;

    public int BrickValue;
    public int HitPoints;

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
        // Swapn a random Power-Up with a chance of 60%
        if (Random.value <= 0.60)
            Instantiate(PowerUpPrefabs[Random.Range(0, 4)], transform.position, Quaternion.identity);
    }

    public void AddPoints(int point)
    {
        GameManager.Score += point;
        GameManagerEndless.Score += point;
    }
}
