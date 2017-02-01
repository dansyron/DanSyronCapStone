using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

	GameObject startTile;
	GameObject OceanPlane;
	GameObject sunLight;

	public List<GameObject> solutionList;

	float randomLightangle;

	// Use this for initialization
	void Start () {

		//calculate random sunlight angle.
		randomLightangle = (float)(Random.Range(-80, 81));

		//create the new solution list
		solutionList = new List<GameObject> ();

		sunLight = (GameObject)Instantiate (Resources.Load ("Lights/SunLightObject"), Vector3.zero, Quaternion.identity);
		sunLight.transform.Rotate(new Vector3( 90f, 0, 0));


		OceanPlane = Resources.Load<GameObject> ("OceanPlane");

		//create ocean plane or other object.
		Instantiate (OceanPlane, Vector3.zero, Quaternion.identity);

		//create the new start tile
		startTile = (GameObject)(Instantiate (Resources.Load ("BasicTile"), Vector3.zero, Quaternion.identity));
		
	}
	
	// Update is called once per frame
	void Update () {



	}



}
