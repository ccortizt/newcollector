using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour {

    private int score;
    GameObject exp;

	void Start () {
        score = 0;
	}
	
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Apple"))
        {
            scorePlusOne();
            
            if(gameObject.name.Contains("Player"))
                exp = (GameObject)Instantiate(Resources.Load("Prefabs/ExplosionPlayer"), transform.position, Quaternion.identity);
            else
                exp = (GameObject)Instantiate(Resources.Load("Prefabs/ExplosionEnemy"), transform.position, Quaternion.identity);
            Destroy(exp, 1);
            Destroy(coll.gameObject);
            
        }

    }

    public void scorePlusOne()
    {
        score++;
        gameObject.transform.FindChild("Canvas").transform.FindChild("Text").GetComponent<Text>().text = "" + score;

    }

    public int GetScore()
    {
        return score;
    }
}
