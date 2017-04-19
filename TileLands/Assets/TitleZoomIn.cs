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
		speed = 8f;

		menuActivated = false;
		menuTriggered = false;

	}

	// Update is called once per frame
	void Update () {

		if (movingin) {

			currentPosition = transform.position.x;



			if (transform.position.x < -2) {
				transform.position = new Vector3 (currentPosition += speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
			}

			else if (-2 <= transform.position.x && transform.position.x < 0) {

				if (speed > 0) {
					speed -= .1f;
				}
				transform.position = new Vector3 (currentPosition += speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
			}

			else if (speed <= 0 || transform.position.x >= 0){
				movingin = false;

				if (!menuActivated)
				{
					transform.position = new Vector3(0, transform.position.y, transform.position.z);
				}
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
