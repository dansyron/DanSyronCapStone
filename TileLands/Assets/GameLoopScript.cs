using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

	GameObject GameCube;

	// Use this for initialization
	void Start () {

		GameCube = Resources.Load<GameObject> ("BasicTile");
		//instantiate new gamecube
		Instantiate(GameCube, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
