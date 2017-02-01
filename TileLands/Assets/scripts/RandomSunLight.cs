using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSunLight : MonoBehaviour {

	int randomLightAngle;

	// Use this for initialization
	void Start () {

	
		randomLightAngle = Random.Range (-80, 81);

		transform.Rotate(new Vector3(randomLightAngle, 0, 0));

		if (Mathf.Abs (randomLightAngle) > 50) {
			GetComponent<Light> ().intensity = 2.5f;
			GetComponent<Light> ().color = new Color (.73f, .3f, 0);

		} else if (Mathf.Abs (randomLightAngle) <= 50 && Mathf.Abs (randomLightAngle) > 30) {
			GetComponent<Light> ().intensity = 1f;
			GetComponent<Light> ().color = new Color (.1f, .05f, .6f);
		} else {
			GetComponent<Light> ().intensity = .80f;
			GetComponent<Light> ().color = new Color (1f, .85f, .75f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
