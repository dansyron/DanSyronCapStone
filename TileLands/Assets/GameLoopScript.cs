using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

	GameObject startTile;
	public List<GameObject> solutionList;

	// Use this for initialization
	void Start () {

		//create the new solution list
		solutionList = new List<GameObject> ();

		//create the new start tile
		startTile = (GameObject)(Instantiate (Resources.Load ("BasicTile"), Vector3.zero, Quaternion.identity));
		
	}
	
	// Update is called once per frame
	void Update () {
	}



}
