using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenFade : MonoBehaviour {


	float alpha = 1;
	// Use this for initialization
	void Start () {
		GetComponent<CanvasGroup> ().alpha = alpha;
	}
	
	// Update is called once per frame
	void Update () {

		if (PuzzleGeneratorScript.instance.GetComponent<PuzzleGeneratorScript> ().GameReady) {

				alpha -= .05f;
				GetComponent<CanvasGroup> ().alpha = alpha;

			if (alpha <= 0) {
				Destroy (gameObject);
			}
		}	
	}
}
