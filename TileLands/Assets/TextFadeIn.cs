using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadeIn : MonoBehaviour {


	float alpha = 0;
	bool fading;

	// Use this for initialization
	void Start () {
		fading = true;
		GetComponent<CanvasGroup> ().alpha = alpha;

	}

	// Update is called once per frame
	void Update () {

		if (fading) {
			if (alpha < 1) {
				alpha += .1f;
			} else
				fading = false;
			GetComponent<CanvasGroup> ().alpha = alpha;
		}



	}
}
