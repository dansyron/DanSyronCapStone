using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGeneratorScript : MonoBehaviour {

	List<GameObject> SolutionTiles;
	Vector3 currentPosition;
	GameObject GenerationCube;
	public static PuzzleGeneratorScript instance;
	int easyEvolutions;
	//int mediumEvolutions;
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

		SolutionTiles = new List<GameObject>();

		//placeholder evolution levels
		easyEvolutions = 5;
		//mediumEvolutions = 10;
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
		for (int i = 0; i < easyEvolutions; i++) 
		{
			//creates new random
			newRandomCubeInt = Random.Range (0, SolutionTiles.Count);

			if (newRandomCubeInt != randomCheck) 
			{
				SolutionTiles [newRandomCubeInt].GetComponent<GenerationTileScript>().Toggle();
			}
			randomCheck = newRandomCubeInt; 
		}

		//create the incorrect solution grid

		//create the solution tiles from the finished solution



			


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
