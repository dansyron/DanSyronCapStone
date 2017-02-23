using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RotateLeft : MonoBehaviour {
	Button button;

	void Awake()
	{
		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

		if (GameManagerScript.instance.gameActive)
		{

		if (!GameLoopScript.instance.GetComponent<GameLoopScript> ().rotatingCameraLeft && !GameLoopScript.instance.GetComponent<GameLoopScript> ().rotatingCameraRight)
			{

		//execute on command
		button.onClick.AddListener((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript>().CameraIsRotatingLeft); 
		button.onClick.AddListener((UnityAction)GameLoopScript.instance.GetComponent<GameLoopScript>().RotateCameraLeft);  
			}
		}
	}

	void TaskOnClick(){
		AudioManager.Instance.PlaySwoosh ();
		AudioManager.Instance.PlayButton1 ();
	}
}