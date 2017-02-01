using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleRiseScript : MonoBehaviour {

	bool hasRisen;
	bool hasFallen;
	float currentY;
	float riseValue;


	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, -2f, transform.position.z);
		riseValue = 6f;
		currentY = transform.position.y;
		hasRisen = false;	
		hasFallen = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasRisen) {
			if (currentY < 0) {
				currentY += riseValue * Time.deltaTime;
				transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
			} else {
				hasRisen = true;
				transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
			}
		}
			
		
	}

	//destroys prefab

		
}
