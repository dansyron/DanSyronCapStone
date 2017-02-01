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
			//SUNSET SETTINGS
			GetComponent<Light> ().intensity = 2.5f;
			GetComponent<Light> ().color = new Color (.73f, .3f, 0);

			//change global ambient settings
			RenderSettings.ambientLight = new Color (.7f, .6f, .4f);


		} else if (Mathf.Abs (randomLightAngle) <= 50 && Mathf.Abs (randomLightAngle) > 30) {
			//NIGHT SETTINGS
			GetComponent<Light> ().intensity = 1f;
			GetComponent<Light> ().color = new Color (.1f, .05f, .6f);
			//change global ambient settings
			RenderSettings.ambientLight = new Color (.2f, .1f, .6f);


		} else {

			//DAY SETTINGS
			GetComponent<Light> ().intensity = .80f;
			GetComponent<Light> ().color = new Color (1f, .85f, .75f);
			//change global ambient settings
			RenderSettings.ambientLight = new Color (.6f, .8f, .8f);

		}
			

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
