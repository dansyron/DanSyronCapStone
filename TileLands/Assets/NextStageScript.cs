using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class NextStageScript : MonoBehaviour {
	
	Button button;


	void Start()
	{
		
		  button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

			//make the new game canvas
			button.onClick.AddListener ((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript> ().GoToNextStage); 
	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton1 ();
	}
}
