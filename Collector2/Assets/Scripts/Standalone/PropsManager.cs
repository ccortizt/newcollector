using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class PropsManager : MonoBehaviour
{

    public GameObject prop;
    public GameObject prop1;
    public GameObject prop2;
    public GameObject prop3;
    public GameObject prop4;
    public GameObject prop5;

    private float xPos = 4;
    private float yPos = 0.3f;
    private float zPos = 4;
    public float spawnTime = 2f;
    public int maximumAppleInstantiated;

    void Start()
    {
        StartCoroutine(SpawnProps(spawnTime, 40));
    }

    private IEnumerator SpawnProps(float period, int numberProps)
    {
        for (int i = 0; i < numberProps; i++)
        {
            for (int j = 0; j < Random.Range(1, maximumAppleInstantiated); j++)
            {
                spawn();
            }
            yield return new WaitForSeconds(period);
        }

    }

    public void spawn()
    {
        float prob = Random.Range(0, 100);

        if (prob >= 0 && prob < 40)
        {
            GameObject apple = Instantiate(prop, new Vector3(Random.Range(-xPos, xPos), yPos, Random.Range(-zPos, zPos)), Quaternion.identity);
            apple.GetComponent<AppleController>().enabled = true;
        }


        if (prob >= 40 && prob < 50)
        {
            GameObject apple = Instantiate(prop1, new Vector3(Random.Range(-xPos, xPos), yPos, Random.Range(-zPos, zPos)), Quaternion.identity);
            apple.GetComponent<AppleController>().enabled = true;
            
        }


        if (prob >= 50 && prob < 65)
        {
            GameObject apple = Instantiate(prop2, new Vector3(Random.Range(-xPos, xPos), yPos, Random.Range(-zPos, zPos)), Quaternion.identity);
            apple.GetComponent<AppleController>().enabled = true;
        }
         

        if (prob >= 65 && prob < 80)
        {
            GameObject apple = Instantiate(prop3, new Vector3(Random.Range(-xPos, xPos), yPos, Random.Range(-zPos, zPos)), Quaternion.identity);
            apple.GetComponent<AppleController>().enabled = true;
        }
         

        if (prob >= 80 && prob < 88)
        {
            GameObject apple = Instantiate(prop4, new Vector3(Random.Range(-xPos, xPos), yPos, Random.Range(-zPos, zPos)), Quaternion.identity);
            apple.GetComponent<AppleController>().enabled = true;
        }


        if (prob >= 88 && prob < 100)
        {
            GameObject apple = Instantiate(prop5, new Vector3(Random.Range(-xPos, xPos), yPos, Random.Range(-zPos, zPos)), Quaternion.identity);
            apple.GetComponent<AppleController>().enabled = true;    
        }
        
    }

}
