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


		if (gameObject.tag == "easyselector") {
			//set difficulty to test value
			GameSettingsScript.instance.setDifficulty = GameSettingsScript.instance.EASY_EVOLUTIONS;
		}

		else if (gameObject.tag == "mediumselector") {
			//set difficulty to test value
			GameSettingsScript.instance.setDifficulty = GameSettingsScript.instance.MED_EVOLUTIONS;
		}

		else if (gameObject.tag == "hardselector") {
			//set difficulty to test value
			GameSettingsScript.instance.setDifficulty = GameSettingsScript.instance.HARD_EVOLUTIONS;
		}

		else if (gameObject.tag == "expertselector") {
			//set difficulty to test value
			GameSettingsScript.instance.setDifficulty = GameSettingsScript.instance.EXPERT_EVOLUTIONS;
		}

		else if (gameObject.tag == "masterselector") {
			//set difficulty to test value
			GameSettingsScript.instance.setDifficulty = GameSettingsScript.instance.MASTER_EVOLUTIONS;
		}

		MainMenuScript.instance.goToMainGame = true;
	}
}
