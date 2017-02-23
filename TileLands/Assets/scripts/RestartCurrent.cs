using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RestartCurrent : MonoBehaviour {
	Button button;

	void Awake()
	{
		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

		if (GameManagerScript.instance.gameActive) {
			//execute on command
			button.onClick.AddListener ((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript> ().ResetMoves);
		}
	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton3 ();
	}
}