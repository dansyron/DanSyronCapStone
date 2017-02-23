using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleZoomIn : MonoBehaviour {


	float speed;
	float currentPosition;

	GameObject MainMenuInterface;

	bool movingin = true;

	bool menuTriggered;

	bool menuActivated;

	// Use this for initialization
	void Start () {
		speed = 12f;

		menuActivated = false;
		menuTriggered = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (movingin) {

			currentPosition = transform.position.x;

			if (transform.position.x < 0) {
				transform.position = new Vector3 (currentPosition += speed * Time.deltaTime, transform.position.y, transform.position.z);
			}
			 else {
				movingin = false;
				menuActivated = true;
			}

			if (speed <= 0) {
				movingin = false;
				menuActivated = true;

			}

			if (menuActivated && !menuTriggered) {
				//instantiates the end gamvas
				MainMenuInterface = (GameObject)Instantiate(Resources.Load ("Menus/MainMenuCanvas"), Vector3.zero, Quaternion.identity);
				menuActivated = false;
				menuTriggered = true;
			}

		}

		
	}
}
