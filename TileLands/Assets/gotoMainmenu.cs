using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class gotoMainmenu : MonoBehaviour {

	Button button;


	void Start()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);


	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton1 ();
		//make the new game canvas
		SceneManager.LoadScene("MainMenuScene");
	}
}
