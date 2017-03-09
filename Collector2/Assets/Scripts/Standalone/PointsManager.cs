using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{

    private int score;
    GameObject exp;
    private float effectTime = 4f;

    private bool canAddScore;

    void Start()
    {
        canAddScore = true;
        score = 0;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Apple"))
        {

            if (canAddScore)
            {
                scorePlus(coll.gameObject.GetComponent<AppleController>().GetScoreToAdd());

                if (gameObject.name.Contains("Player"))
                    exp = (GameObject)Instantiate(Resources.Load("Prefabs/VfxExplosionPlayer"), transform.position, Quaternion.identity);
                else
                    exp = (GameObject)Instantiate(Resources.Load("Prefabs/VfxExplosionEnemy"), transform.position, Quaternion.identity);
                Destroy(exp, 1);
                Destroy(coll.gameObject);

                if (coll.gameObject.name.Contains("Blue"))
                {
                    gameObject.transform.FindChild("VfxFrostSphere").gameObject.SetActive(true);
                    gameObject.transform.FindChild("VfxSlowed").gameObject.SetActive(false);
                    gameObject.transform.FindChild("VfxStar").gameObject.SetActive(false);
                    StartCoroutine(DisableEffect("Blue", effectTime));
                }

                if (coll.gameObject.name.Contains("Yellow"))
                {
                    gameObject.transform.FindChild("VfxSlowed").gameObject.SetActive(true);
                    gameObject.transform.FindChild("VfxFrostSphere").gameObject.SetActive(false);
                    gameObject.transform.FindChild("VfxStar").gameObject.SetActive(false);
                    StartCoroutine(DisableEffect("Yellow", effectTime));
                }

                if (coll.gameObject.name.Contains("Purple"))
                {
                    gameObject.transform.FindChild("VfxStar").gameObject.SetActive(true);
                    gameObject.transform.FindChild("VfxSlowed").gameObject.SetActive(false);
                    gameObject.transform.FindChild("VfxFrostSphere").gameObject.SetActive(false);
                    StartCoroutine(DisableEffect("Purple", effectTime));
                }

                if (coll.gameObject.name.Contains("Random"))
                {
                    //gameObject.transform.FindChild("Canvas").transform.FindChild("Text").GetComponent<Text>().text = "" + score;
                }
            }



        }

    }

    public void scorePlus(int scoreToAdd)
    {
        score += scoreToAdd;

        if (gameObject.name.Equals("Player"))
        {
            GameObject.FindGameObjectWithTag("PlayerScore").GetComponent<Text>().text = "" + score;
        }
        if (gameObject.name.Equals("Enemy"))
        {
            GameObject.FindGameObjectWithTag("EnemyScore").GetComponent<Text>().text = "" + score;
        }

    }

    public int GetScore()
    {
        return score;
    }

    public void CantAddPoints()
    {
        canAddScore = false;
    }

    public IEnumerator DisableEffect(string effect, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (effect.Contains("Blue"))
        {
            gameObject.transform.FindChild("VfxFrostSphere").gameObject.SetActive(false);
        }

        if (effect.Contains("Yellow"))
        {
            gameObject.transform.FindChild("VfxSlowed").gameObject.SetActive(false);
        }

        if (effect.Contains("Purple"))
        {
            gameObject.transform.FindChild("VfxStar").gameObject.SetActive(false);
        }

    }
}
