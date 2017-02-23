using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class ReturnToMainMenu : MonoBehaviour {

	Button button;


	void Start()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);
		button.onClick.AddListener ((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript> ().ReturnToMainMenu); 

	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton1 ();
		//make the new game canvas

	}
}
