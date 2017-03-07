using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMainGame : MonoBehaviour {

	Button button;


	void Start()
	{
		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton1 ();
		//make the new game canvas

		//set difficulty to test value
		GameSettingsScript.instance.setDifficulty= GameSettingsScript.instance.EXPERT_EVOLUTIONS;

		MainMenuScript.instance.goToMainGame = true;
	}
}
