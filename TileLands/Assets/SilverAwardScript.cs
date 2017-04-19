using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilverAwardScript : MonoBehaviour {

	Text txt;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		txt.text = "Silver Medals: "+ GameSettingsScript.instance.SILVER_MEDALS_EARNED;
	}

	// Update is called once per frame
	void Update () {

	}

}
