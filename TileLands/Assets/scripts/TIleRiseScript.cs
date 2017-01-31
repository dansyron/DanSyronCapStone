using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleRiseScript : MonoBehaviour {

	bool hasRisen;
	float currentY;
	float riseValue;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, -6f, transform.position.z);
		riseValue = .1f;
		currentY = transform.position.y;
		hasRisen = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		while (!hasRisen) {
			if (currentY < 0) {
				currentY += riseValue;
				transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
			} else {
				hasRisen = true;
			}
		}
			
		
	}
		
}
