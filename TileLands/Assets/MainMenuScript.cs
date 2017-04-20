using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {


	public static MainMenuScript instance;

	public bool goToMainGame;

	float mainGameTransitionCounter;

	GameObject transitionInterface;

	//create lights
	GameObject MainMenuLight;

	// Use this for initialization
	void Start () {
		instance = this;
		mainGameTransitionCounter = 0;

		AudioManager.Instance.PlayMenuSound ();
		MainMenuLight = (GameObject)Instantiate (Resources.Load ("Menus/MenuLight"), Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

		if (goToMainGame) {

			mainGameTransitionCounter += .1f;
			transitionInterface = (GameObject)Instantiate(Resources.Load ("EndingCanvas"), Vector3.zero, Quaternion.identity);

			//reset stage
			if (mainGameTransitionCounter > 1.2) {
				mainGameTransitionCounter = 0;
				SceneManager.LoadScene("Tile Test Scene");
			}

		}

	}
}
