using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TurnsTaken : MonoBehaviour {

	Text txt;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		txt.text = "Turns: " + GameLoopScript.instance.GetComponent<GameLoopScript> ().turns;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
