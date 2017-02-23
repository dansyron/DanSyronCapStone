using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RotateRight : MonoBehaviour {
	Button button;

	void Awake()
	{
		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

		if (GameManagerScript.instance.gameActive) {


			//execute on command 
			if (!GameLoopScript.instance.GetComponent<GameLoopScript> ().rotatingCameraLeft && !GameLoopScript.instance.GetComponent<GameLoopScript> ().rotatingCameraRight) {

				button.onClick.AddListener ((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript> ().CameraIsRotatingRight); 
				button.onClick.AddListener ((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript> ().RotateCameraRight);  
			}
		}

	}

	void TaskOnClick(){
		AudioManager.Instance.PlaySwoosh ();
		AudioManager.Instance.PlayButton1 ();
	}
}