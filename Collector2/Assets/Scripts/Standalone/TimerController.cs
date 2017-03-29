using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class TimerController : MonoBehaviour
{

    public Text timerCountText;
    public float timeLeft;
    private bool timerOn;

    private GameObject endGameHUD;
    void Start()
    {
        Debug.Log("STARTING GAME");
        timeLeft = 120f;
        timerOn = true;
    }

    void Update()
    {

        if (timerOn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft >= 0)
            {
                timerCountText.text = Mathf.Round(timeLeft).ToString();
            }
            if (timeLeft <= 0)
            {
                timerCountText.text = "0";
                timerOff();
                GameObject.Find("Enemy").GetComponent<IAPlayerController>().enabled = false;
                GameObject.Find("Enemy").GetComponent<NavMeshAgent>().enabled = false;
                GameObject.Find("Enemy").GetComponent<PointsManager>().CantAddPoints();
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Player").GetComponent<PointsManager>().CantAddPoints();
                StartCoroutine(enableEnd());
            }
        }

    }

    IEnumerator enableEnd()
    {

        yield return new WaitForSeconds(1);

        endGameHUD = (GameObject)Instantiate(Resources.Load("Prefabs/EndGameHUD"), Vector3.zero, Quaternion.identity);
        endGameHUD.name = "EndGameHUD";

        int enemyScore = GameObject.Find("Enemy").GetComponent<PointsManager>().GetScore();
        int playerScore = GameObject.Find("Player").GetComponent<PointsManager>().GetScore();

        if (enemyScore < playerScore)
        {
            GameObject.Find("EndGameHUD").transform.FindChild("Panel/VictoryText").gameObject.SetActive(true);
        }
        else if (enemyScore > playerScore)
        {
            GameObject.Find("EndGameHUD").transform.FindChild("Panel/DefeatText").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("EndGameHUD").transform.FindChild("Panel/DrawText").gameObject.SetActive(true);
        }


    }

    public void timerOff()
    {
        timerOn = false;
    }
}
