using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medalFlashScript : MonoBehaviour {

	// Use this for initialization


	float alpha = 0;
	bool flashing;
	bool fading;
	bool playedMedalSound;
	float medalCounter = 0;

	// Use this for initialization
	void Start () {
		flashing = true;
		fading = false;
		GetComponent<CanvasGroup> ().alpha = alpha;
		playedMedalSound = false;


	}

	// Update is called once per frame
	void Update ()
	{


		medalCounter += 1 * Time.fixedDeltaTime;

		if (medalCounter > .75f) 
		{
			if (!playedMedalSound) {
				AudioManager.Instance.PlayMedalSound ();
				playedMedalSound = true;
			}
			if (flashing) {
				if (alpha < 1) {
					alpha += .2f;
				} else {
					flashing = false;
					fading = true;
				}
				GetComponent<CanvasGroup> ().alpha = alpha;
			} 


		}

		if (medalCounter > 1) {
			if (fading) 
			{
				if (alpha > 0) {
					alpha -= .1f;
				} else {
					alpha = 0;
					Destroy (gameObject);
				}
				GetComponent<CanvasGroup> ().alpha = alpha;
			}
		}


	}
}

