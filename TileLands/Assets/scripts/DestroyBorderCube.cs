using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBorderCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider collision) 
	{
		if (collision.gameObject.tag == "SolutionTile") {
			//Destroy (collision.gameObject);
			Destroy (gameObject);
		}
	}
}
