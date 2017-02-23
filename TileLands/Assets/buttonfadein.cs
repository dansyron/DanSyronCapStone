using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonfadein : MonoBehaviour {


	float alpha = 0;
	// Use this for initialization
	void Start () {
		GetComponent<CanvasGroup> ().alpha = alpha;
	}

	// Update is called once per frame
	void Update () {

		if (alpha < 1) {
			alpha += .05f;
		}
		GetComponent<CanvasGroup> ().alpha = alpha;
	}
}
