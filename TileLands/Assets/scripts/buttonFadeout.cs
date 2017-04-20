using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFadeout : MonoBehaviour {

	float canvasAlpha = 1;

	// Use this for initialization
	void Start () {
		GetComponent<CanvasGroup> ().alpha = canvasAlpha;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameLoopScript.instance.GameWon) {
			canvasAlpha -= .05f;
			GetComponent<CanvasGroup> ().alpha = canvasAlpha;
		}

		if (canvasAlpha <= 0) {
			GetComponent<CanvasGroup> ().gameObject.SetActive (false);
		}

	}
}
