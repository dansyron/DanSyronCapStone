using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuitButton : MonoBehaviour {
	Button button;

	void Awake()
	{
		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton3 ();
		Application.Quit ();
	}
}
