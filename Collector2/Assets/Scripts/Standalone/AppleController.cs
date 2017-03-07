using UnityEngine;
using System.Collections;

public class AppleController : MonoBehaviour {


    private int normalNumberMovements = 3;
    
    private float maxForceProportion = 15f;    

	void Start () {

        AppleMovement();
        StartCoroutine(RandomAppleMovementCycle(GetRandom(1, 5), normalNumberMovements));

	}

    private void AppleMovement()
    {
        if (Random.Range(0, 2) == 0){
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * GetRandom(-maxForceProportion, maxForceProportion); 
        }

        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.right * GetRandom(-maxForceProportion, maxForceProportion);
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
            AppleMovement();
            yield return new WaitForSeconds(period);
        }

    }

    //void OnCollisionEnter(Collision coll)
    //{

    //    Debug.Log("n " + coll.gameObject.name);
    //    if (coll.gameObject.name.Contains("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}

