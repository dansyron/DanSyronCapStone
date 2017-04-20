using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteButton : MonoBehaviour {


	// Use this for initialization
	void Start () {
		if (GameSettingsScript.instance.Muted) {
			GetComponent<Toggle> ().isOn = true;
		} else {
			GetComponent<Toggle> ().isOn = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Toggle> ().isOn) {
			AudioManager.Instance.MuteAll ();
		}

		else AudioManager.Instance.unMuteAll ();
	}


}
