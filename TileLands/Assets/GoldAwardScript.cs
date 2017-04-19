using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldAwardScript : MonoBehaviour {

	Text txt;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		txt.text = "Gold Medals: "+ GameSettingsScript.instance.GOLD_MEDALS_EARNED;
	}

	// Update is called once per frame
	void Update () {

	}
}
