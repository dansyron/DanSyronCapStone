using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesToggledScript : MonoBehaviour {

	Text txt;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		txt.text = "Tiles Toggled: "+ GameSettingsScript.instance.TOTAL_TILES_TOGGLED;
	}

	// Update is called once per frame
	void Update () {

	}
}
