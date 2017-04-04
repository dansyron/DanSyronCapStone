using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TimedFadeout : MonoBehaviour {

	float alpha = 1;
	float logoDuration = 3f;
	float currentTime  = 0f;
	bool fadeout;

	// Use this for initialization
	void Start () {
		fadeout = false;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += 1 * Time.fixedDeltaTime;

		if (currentTime > logoDuration) {
			fadeout = true;
		}

		if (fadeout) {
			if (alpha > 0) {
				alpha -= .1f;
				GetComponent<CanvasGroup> ().alpha = alpha;
			} else if (alpha < 0) {
				//load the new scene in the stack
				SceneManager.LoadScene("MainMenuScene");
			}

		}
		
	}
}
