using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyMovementScript : MonoBehaviour {

	float skyMovementspeed = 10f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		MoveSky ();
	}

	void MoveSky()
	{
		transform.position = new Vector3 (skyMovementspeed * Time.deltaTime, transform.position.y, transform.position.z);
	}
}
