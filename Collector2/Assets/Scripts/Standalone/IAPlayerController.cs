using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.AI;

public class IAPlayerController : MonoBehaviour
{

    private GameObject target;
    private int score = 0;
    private int playerScore = 0;

    void Start()
    {

        GetComponent<MeshRenderer>().material.color = Color.yellow;
        gameObject.transform.FindChild("Canvas/Text").GetComponent<Text>().color = Color.black;
    }

    void Update()
    {
        transform.Rotate(new Vector3(90, 0, 0));
        transform.position += new Vector3(0, 0.4f, 0);
        try
        {
            target = GameObject.FindGameObjectWithTag("GoodApple");
            if (target != null)
                gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
            else
            {
                target = GameObject.FindGameObjectWithTag("GoodApple");
                gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
            }
            //PrintTarget();
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex);
        }

        CheckScores();
        UpdateDifficulty();

    }


    private void CheckScores()
    {
        score = GetComponent<PointsManager>().GetScore();
        playerScore = GameObject.Find("Player").GetComponent<PointsManager>().GetScore();
    }

    private void UpdateDifficulty()
    {
        float acceleration = gameObject.GetComponent<NavMeshAgent>().acceleration;
        float speed = gameObject.GetComponent<NavMeshAgent>().speed;

        int deltaScore = score - playerScore; //+ if enemy wins ... - if player wins 

        gameObject.GetComponent<NavMeshAgent>().speed = SetNewSpeed(deltaScore);
        gameObject.GetComponent<NavMeshAgent>().acceleration = SetNewAcceleration(deltaScore);

        //if ((deltaScore == 0))
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 9;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 13;
        //}


        //if ((deltaScore == 1) )
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed  = 8;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 12;
        //}

        //if ((deltaScore == 2))
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 7;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 11;
        //}

        //if (deltaScore == 3 )
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 6;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 10;
        //}

        //if ((deltaScore) > 5 )
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 5;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 8;
        //}

        //if ((deltaScore) < -5 )
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 13;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 16;
        //}

        //if ((deltaScore) == -4 )
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 12;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 15;
        //}

        //if ((deltaScore) == -3 )
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 11;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 14;
        //}

        //if ((deltaScore) == -1  )
        //{
        //    gameObject.GetComponent<NavMeshAgent>().speed = 10;
        //    gameObject.GetComponent<NavMeshAgent>().acceleration = 13;
        //}

        //Debug.Log("V: " + gameObject.GetComponent<NavMeshAgent>().speed + " A: " + gameObject.GetComponent<NavMeshAgent>().acceleration);

    }

    void PrintTarget()
    {
        Debug.Log(target);
    }

    private int SetNewSpeed(int delta)
    {
        if (delta < -10)
            return 19;
        else if (delta > 6)
            return 3;
        else
            return -delta + 9;
    }

    private int SetNewAcceleration(int delta)
    {
        if (delta < -10)
            return 22;
        else if (delta > 7)
            return 5;
        else
            return -delta + 12;
    }


}
