using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

	GameObject startTile;
	GameObject sunLight;
	GameObject ocean;
	GameObject EnvironmentPlane;

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

		//create ocean;
		ocean = Resources.Load<GameObject> ("OceanPlane");
		//create ocean plane or other object.
		EnvironmentPlane = (GameObject)Instantiate (ocean, Vector3.zero, Quaternion.identity);




		//create the new start tile
		startTile = (GameObject)(Instantiate (Resources.Load ("BasicTile"), Vector3.zero, Quaternion.identity));
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.R))
			{
				{

					//restart scene
				}
			}

	}




}
