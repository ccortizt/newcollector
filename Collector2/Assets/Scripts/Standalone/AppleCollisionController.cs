using System;
using System.Collections.Generic;
using UnityEngine;
public class AppleCollisionController: MonoBehaviour{

    private bool hasSpeedEffect;
    private float speedPercentageModifier;

    private int scoreToGive;

    void Start()
    {
        AssignEffect();
        AssignScore();
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

    private void AssignEffect()
    {
        if (gameObject.name.Contains("Red"))
        {
            hasSpeedEffect = false;
        }

        if (gameObject.name.Contains("Green"))
        {
            hasSpeedEffect = false;
        }

        if (gameObject.name.Contains("Blue"))
        {
            hasSpeedEffect = true;
            speedPercentageModifier = 0;
        }

        if (gameObject.name.Contains("Yellow"))
        {
            hasSpeedEffect = true;
            speedPercentageModifier = 50;
        }

        if (gameObject.name.Contains("Purple"))
        {
            hasSpeedEffect = true;
            speedPercentageModifier = 300;
        }

        if (gameObject.name.Contains("Random"))
        {
            hasSpeedEffect = false;
        }
    }


    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.name.Contains("Player"))
        {
            if (this.hasSpeedEffect)
                coll.gameObject.GetComponent<PlayerController>().SetMoveSpeed(speedPercentageModifier);
        }

        if (coll.gameObject.name.Contains("Enemy"))
        {
            if (this.hasSpeedEffect)
                coll.gameObject.GetComponent<IAPlayerController>().SetMoveSpeed(speedPercentageModifier);
        }
    }


    public int GetScoreToAdd()
    {
        return scoreToGive;
    }
}