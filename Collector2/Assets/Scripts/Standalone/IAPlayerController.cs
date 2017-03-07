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

    public float moveSpeedPercentage = 100;
    private float defaultMoveSpeedPercentage = 100;
    private float effectTime = 4f;
    private bool isUnderEffect;


    void OnAwake()
    {
        moveSpeedPercentage = defaultMoveSpeedPercentage;
        isUnderEffect = false;
    }
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

        gameObject.GetComponent<NavMeshAgent>().speed = SetNewSpeed(deltaScore) / 100f * moveSpeedPercentage;
        
        gameObject.GetComponent<NavMeshAgent>().acceleration = SetNewAcceleration(deltaScore);

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

    public void SetMoveSpeed(float percentage)
    {
        if (isUnderEffect)
        {
            RestoreMoveSpeed();
        }

        moveSpeedPercentage = percentage;
        isUnderEffect = true;
        StartCoroutine(RestoreMoveSpeedDelayed());
    }

    public IEnumerator RestoreMoveSpeedDelayed()
    {
        yield return new WaitForSeconds(effectTime);
        isUnderEffect = false;
        RestoreMoveSpeed();
    }

    private void RestoreMoveSpeed()
    {
        moveSpeedPercentage = defaultMoveSpeedPercentage;
    }
}
