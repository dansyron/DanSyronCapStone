using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PickDifficulty : MonoBehaviour {

	Button button;
	GameObject difficultyInterface;

	void Start()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);



	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton1 ();
		//make the new game canvas
		//create the new menu for the difficulty selection

		difficultyInterface = (GameObject)Instantiate(Resources.Load ("Menus/DifficultyCanvas"), Vector3.zero, Quaternion.identity);
		//difficultyInterface.GetComponent<Canvas> ().worldCamera = GameManagerScript.instance.mainCamera.GetComponent<Camera>();

		gameObject.SetActive (false);
		//has to destroy game object
	}
		

}