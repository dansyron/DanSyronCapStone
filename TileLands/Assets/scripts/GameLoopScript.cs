using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

	public static GameLoopScript instance;

	GameObject startTile;
	GameObject sunLight;
	GameObject ocean;
	GameObject EnvironmentPlane;
	GameObject gameCube;

	public List<GameObject> solutionList;
	public List<GameObject> activeCubeList;

	float randomLightangle;

	// Use this for initialization
	void Start () {


		//create instance of this object
		instance = this;

		//calculate random sunlight angle.
		randomLightangle = (float)(Random.Range(-80, 81));

		//create the new solution list
		solutionList = new List<GameObject> ();

		//list of all active cubes
		activeCubeList = new List<GameObject> ();
	

		sunLight = (GameObject)Instantiate (Resources.Load ("Lights/SunLightObject"), Vector3.zero, Quaternion.identity);
		sunLight.transform.Rotate(new Vector3( 90f, 0, 0));

		//create ocean;
		ocean = Resources.Load<GameObject> ("OceanPlane");
		//create ocean plane or other object.
		EnvironmentPlane = (GameObject)Instantiate (ocean, Vector3.zero, Quaternion.identity);

		gameCube = Resources.Load<GameObject> ("BasicTile");

		//create the new start tile
		//startTile = (GameObject)(Instantiate (Resources.Load ("BasicTile"), Vector3.zero, Quaternion.identity));

		CreateCube (Vector3.zero);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.R))
			{
				{

					//restart scene
				ResetGameScene();
				}
			}

	}

	public void ResetGameScene()
	{
		SceneManager.LoadScene("Tile Test Scene");
	}


	public void CreateCube(Vector3 position)
	{
		activeCubeList.Add(Instantiate(gameCube, position, Quaternion.identity));
	}

}
