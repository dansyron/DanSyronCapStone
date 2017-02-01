using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGeneratorScript : MonoBehaviour {

	List<GameObject> SolutionTiles;
	Vector3 currentPosition;
	GameObject OceanPlane;
	GameObject GenerationCube;

	public static PuzzleGeneratorScript instance;
	int easyEvolutions;
	int mediumEvolutions;
	//int hardEvolutions;
	//int expertEvolutions;
	int randomCheck;
	int newRandomCubeInt;

	// Use this for initialization
	void Start () 
	{
		//create instance of this object
		instance = this;

		GenerationCube = Resources.Load<GameObject> ("GenerationCube");
		OceanPlane = Resources.Load<GameObject> ("OceanPlane");

		SolutionTiles = new List<GameObject>();

		//placeholder evolution levels
		easyEvolutions = 3;
		mediumEvolutions = 6;
		//hardEvolutions = 15;
		//expertEvolutions = 20;

		newRandomCubeInt = 0;

		randomCheck = -1;

		//add first cube
		CreateCube(Vector3.zero);

		Initialize ();
	}

	void Initialize()
	{
		

		//evolution count
		//create the puzzle
		for (int i = 0; i < mediumEvolutions; i++) 
		{
			//creates new random
			newRandomCubeInt = Random.Range (0, SolutionTiles.Count);

			if (newRandomCubeInt != randomCheck) 
			{
				SolutionTiles [newRandomCubeInt].GetComponent<GenerationTileScript>().Toggle();
			}
			randomCheck = newRandomCubeInt; 
		}

		////create the incorrect solution grid
		//for (int i = -20; i < 21; i++) {
		//	for (int j = -20; j < 21; j++) {
		//		Instantiate (Resources.Load ("BorderCube"), new Vector3 (i, 0, j), Quaternion.identity);
		//	}
		//}

		//generates the solution grid
		for (int i = SolutionTiles.Count - 1; i > -1; i--) {
			Instantiate (Resources.Load ("SolutionGrid"), new Vector3 (SolutionTiles[i].transform.position.x, 0, SolutionTiles[i].transform.position.z), Quaternion.identity);
			//SolutionTiles [i].GetComponent<GenerationTileScript> ().Destroy ();
			//SolutionTiles.RemoveAt (i);
		}

		foreach (GameObject solutionTile in SolutionTiles) {
			solutionTile.GetComponent<GenerationTileScript> ().Destroy ();
		}
		//create the solution tiles from the finished solution

		//clear all solutions
		SolutionTiles.Clear ();


		Instantiate (OceanPlane, Vector3.zero, Quaternion.identity);

		//load game control object
		Instantiate (Resources.Load("GameControlObject"), Vector3.zero, Quaternion.identity);



	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void CreateCube(Vector3 position)
	{
		SolutionTiles.Add(Instantiate(GenerationCube, position, Quaternion.identity));
	}

	public void DestroyCube(GameObject gameObject)
	{
		SolutionTiles.Remove (gameObject);
	}


}
