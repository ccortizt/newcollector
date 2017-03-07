using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class PropsManager : MonoBehaviour
{

    public GameObject prop;
    private float xPos = 4;
    private float yPos = 0.3f;
    private float zPos = 4;
    public float spawnTime = 2f;

    void Start()
    {
        StartCoroutine(SpawnProps(spawnTime, 20));
    }

    private IEnumerator SpawnProps(float period, int numberProps)
    {
        for (int i = 0; i < numberProps; i++)
        {
            for (int j = 0; j < Random.Range(1, 6); j++)
            {
                spawn();
            }            
            yield return new WaitForSeconds(period);
        }
            
    }

    public void spawn()
    {
        Instantiate(prop, new Vector3(Random.Range(-xPos, xPos), yPos, Random.Range(-zPos, zPos)), Quaternion.identity);
    }

}
