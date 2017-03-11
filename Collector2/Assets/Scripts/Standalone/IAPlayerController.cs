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

    GameObject player;

    public GameObject iceProp;
    public GameObject slowProp;
    public GameObject speedProp;

    void OnAwake()
    {
        moveSpeedPercentage = defaultMoveSpeedPercentage;
    }
    void Start()
    {
        player = GameObject.Find("Player");
        gameObject.transform.FindChild("Rabbit_Yellow").gameObject.SetActive(true);
        gameObject.transform.FindChild("Rabbit_Red").gameObject.SetActive(false);
        gameObject.transform.FindChild("Canvas/Text").GetComponent<Text>().color = Color.black;


    }

    void Update()
    {
        
        if(!GetComponent<PlayerController>().GetPowerAcquired().Equals("none")){

            string powerAcquired = GetComponent<PlayerController>().GetPowerAcquired();

            var prop = iceProp;

            if ((int)player.transform.position.x == (int)transform.position.x)
            {
                if (player.transform.position.y < transform.position.y)
                {
                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position - transform.up, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position - transform.up, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position - transform.up, Quaternion.identity);
                    }
                    
                    GetComponent<PlayerController>().SetPowerAcquired("none");

                    prop.GetComponent<AppleController>().SetMovementDisabled();
                    prop.GetComponent<Rigidbody>().velocity = -prop.transform.right * 20;
                }
                else
                {

                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position + transform.up, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position + transform.up, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position + transform.up, Quaternion.identity);
                    }

                     GetComponent<PlayerController>().SetPowerAcquired("none");

                    prop.GetComponent<AppleController>().SetMovementDisabled();
                    prop.GetComponent<Rigidbody>().velocity = prop.transform.right * 20;
                }
            }

            if ((int)player.transform.position.y == (int)transform.position.y)
            {
                if (player.transform.position.y < transform.position.y)
                {

                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position - transform.right, Quaternion.identity);

                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position - transform.right, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position - transform.right, Quaternion.identity);
                    }

                    GetComponent<PlayerController>().SetPowerAcquired("none");

                    prop.GetComponent<AppleController>().SetMovementDisabled();
                    prop.GetComponent<Rigidbody>().velocity = prop.transform.forward * 20;
                }
                else
                {

                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position + transform.right, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position + transform.right, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position + transform.right, Quaternion.identity);
                    }

                    GetComponent<PlayerController>().SetPowerAcquired("none");

                    prop.GetComponent<AppleController>().SetMovementDisabled();
                    prop.GetComponent<Rigidbody>().velocity = -prop.transform.forward * 20;
                }
            }
        }      


        transform.Rotate(new Vector3(90, 0, 0));
        transform.position += new Vector3(0, 0.4f, 0);

        try
        {
            target = GameObject.FindGameObjectWithTag("GoodApple");
            if (target != null)
                gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
            else
            {
                target = GameObject.FindGameObjectWithTag("BadApple");
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
        moveSpeedPercentage = percentage;

        StartCoroutine(RestoreMoveSpeedDelayed());
    }

    public IEnumerator RestoreMoveSpeedDelayed()
    {
        yield return new WaitForSeconds(effectTime);

        RestoreMoveSpeed();
    }

    private void RestoreMoveSpeed()
    {
        moveSpeedPercentage = defaultMoveSpeedPercentage;
    }
}
