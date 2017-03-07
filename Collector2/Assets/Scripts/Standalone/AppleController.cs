﻿using UnityEngine;
using System.Collections;

public class AppleController : MonoBehaviour
{


    private int normalNumberMovements = 3;

    private float maxForceProportion;
    private float minForceProportion;

    private int scoreToGive;

    void Start()
    {
        AssignScore();
        AssignForce();
        AppleMovement();
        StartCoroutine(RandomAppleMovementCycle(GetRandom(1, 5), normalNumberMovements));

    }

    private void AssignForce()
    {
        if (gameObject.name.Contains("Red"))
        {
            minForceProportion = 10f;
            maxForceProportion = 12.5f;
        }

        if (gameObject.name.Contains("Green"))
        {
            minForceProportion = 12.5f;
            maxForceProportion = 15f;
        }

        if (gameObject.name.Contains("Blue"))
        {
            minForceProportion = 0f;
            maxForceProportion = 5f;
        }

        if (gameObject.name.Contains("Yellow"))
        {
            minForceProportion = 0f;
            maxForceProportion = 5f;
        }

        if (gameObject.name.Contains("Purple"))
        {
            minForceProportion = 5f;
            maxForceProportion = 10f;
        }

        if (gameObject.name.Contains("Random"))
        {
            minForceProportion = 15f;
            maxForceProportion = 20f;
        }
    }

    private void AssignScore()
    {
        if (gameObject.name.Contains("Red"))
        {
            scoreToGive = 1;
        }

        if (gameObject.name.Contains("Green"))
        {
            scoreToGive = 3;
        }

        if (gameObject.name.Contains("Blue"))
        {
            scoreToGive = 2;
        }

        if (gameObject.name.Contains("Yellow"))
        {
            scoreToGive = 2;
        }

        if (gameObject.name.Contains("Purple"))
        {
            scoreToGive = 2;
        }

        if (gameObject.name.Contains("Random"))
        {
            scoreToGive = 5;
        }
    }

    private void AppleMovement()
    {

        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * GetRandom(minForceProportion, maxForceProportion);
        }

        else if (rand == 1)
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * -GetRandom(minForceProportion, maxForceProportion);
        }

        else if (rand == 2)
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.right * -GetRandom(minForceProportion, maxForceProportion);
        }

        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.right * GetRandom(minForceProportion, maxForceProportion);
        }

    }

    private float GetRandom(float min, float max)
    {
        return Random.Range(min, max);
    }

    private IEnumerator RandomAppleMovementCycle(float period, int numberTimes)
    {
        for (int i = 0; i < numberTimes; i++)
        {
            AppleMovement();
            yield return new WaitForSeconds(period);
        }

    }

    //void OnCollisionEnter(Collision coll)
    //{

    //    Debug.Log("n " + coll.gameObject.name);
    //    if (coll.gameObject.name.Contains("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public int GetScoreToAdd()
    {
        return scoreToGive;
    }
}


