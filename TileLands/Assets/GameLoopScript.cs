using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

	GameObject startTile;

	// Use this for initialization
	void Start () {

		startTile = (GameObject)(Instantiate (Resources.Load ("BasicTile"), Vector3.zero, Quaternion.identity));

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
