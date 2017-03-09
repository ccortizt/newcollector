using UnityEngine;
using System.Collections;

public class AppleController : MonoBehaviour
{


    private int normalNumberMovements = 3;

    private float maxForceProportion;
    private float minForceProportion;

    //private int scoreToGive;
    //private bool hasSpeedEffect;
    //private float speedPercentageModifier;

    private bool randomMoveEnabled = true;

    void Start()
    {
        //AssignScore();
        AssignForce();
        //AssignEffect();
        AppleMovement();
        StartCoroutine(RandomAppleMovementCycle(GetRandom(1, 5), normalNumberMovements));

    }

    //private void AssignEffect()
    //{
    //    if (gameObject.name.Contains("Red"))
    //    {
    //        hasSpeedEffect = false;
    //    }

    //    if (gameObject.name.Contains("Green"))
    //    {
    //        hasSpeedEffect = false;
    //    }

    //    if (gameObject.name.Contains("Blue"))
    //    {
    //        hasSpeedEffect = true;
    //        speedPercentageModifier = 0;
    //    }

    //    if (gameObject.name.Contains("Yellow"))
    //    {
    //        hasSpeedEffect = true;
    //        speedPercentageModifier = 50;
    //    }

    //    if (gameObject.name.Contains("Purple"))
    //    {
    //        hasSpeedEffect = true;
    //        speedPercentageModifier = 300;
    //    }

    //    if (gameObject.name.Contains("Random"))
    //    {
    //        hasSpeedEffect = false;
    //    }
    //}

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

    //private void AssignScore()
    //{
    //    if (gameObject.name.Contains("Red"))
    //    {
    //        scoreToGive = 1;
    //    }

    //    if (gameObject.name.Contains("Green"))
    //    {
    //        scoreToGive = 3;
    //    }

    //    if (gameObject.name.Contains("Blue"))
    //    {
    //        scoreToGive = 2;
    //    }

    //    if (gameObject.name.Contains("Yellow"))
    //    {
    //        scoreToGive = 2;
    //    }

    //    if (gameObject.name.Contains("Purple"))
    //    {
    //        scoreToGive = 2;
    //    }

    //    if (gameObject.name.Contains("Random"))
    //    {
    //        scoreToGive = 5;
    //    }
    //}

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

            yield return new WaitForSeconds(period);
            if (randomMoveEnabled)
                AppleMovement();
        }

    }

    //void OnCollisionEnter(Collision coll)
    //{

    //    if (coll.gameObject.name.Contains("Player"))
    //    {
    //        if (this.hasSpeedEffect)
    //            coll.gameObject.GetComponent<PlayerController>().SetMoveSpeed(speedPercentageModifier);
    //    }

    //    if (coll.gameObject.name.Contains("Enemy"))
    //    {
    //        if (this.hasSpeedEffect)
    //            coll.gameObject.GetComponent<IAPlayerController>().SetMoveSpeed(speedPercentageModifier);
    //    }
    //}

    //public int GetScoreToAdd()
    //{
    //    return scoreToGive;
    //}

    public void SetMovementDisabled()
    {
        randomMoveEnabled = false;
    }
}


