using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateParticles : MonoBehaviour {

	void Update () {
        
        //transform.Rotate(0, 3, 0);	
        gameObject.transform.LookAt(transform.parent.transform.forward);
	}
}
