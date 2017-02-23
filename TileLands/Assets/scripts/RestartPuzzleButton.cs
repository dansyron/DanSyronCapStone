using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RestartPuzzleButton : MonoBehaviour {
	Button button;

	void Awake()
	{
		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

		if (GameManagerScript.instance.gameActive) {
			//execute on command
			button.onClick.AddListener ((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript> ().ResetGameScene);  
		}
	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton3 ();
	}
}