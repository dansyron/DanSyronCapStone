using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreateOptionsMenu : MonoBehaviour {

	Button button;

	GameObject HowToInterface;

	void Start()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

		//make the new game canvas


	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton1 ();
		HowToInterface = (GameObject)Instantiate(Resources.Load ("Menus/OptionsCanvas"), Vector3.zero, Quaternion.identity);
	}
}
