using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DeleteUI : MonoBehaviour {

	Button button;

	void Start()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick(){
		AudioManager.Instance.PlayButton3 ();
		//make the new game canvas
		Destroy(gameObject.GetComponentInParent<Canvas>().gameObject);
	}
}