﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGeneratorScript : MonoBehaviour {

	List<GameObject> SolutionTiles;
	Vector3 currentPosition;
	GameObject GenerationCube;
	GameObject gameController;

	public static PuzzleGeneratorScript instance;

	int easyEvolutions;
	int mediumEvolutions;
	//int hardEvolutions;
	//int expertEvolutions;
	int randomCheck;
	int newRandomCubeInt;

	bool solutionCreated;
	bool gameLoaded;

	//selects a random game theme
	Theme randomTheme;

	float testCounter;



	//controls the evolution count
	int evolutionCounter;
	int evolutionRequirement;

	// Use this for initialization
	void Start () 
	{
		//create instance of this object
		instance = this;

		testCounter = 0;

		GenerationCube = Resources.Load<GameObject> ("GenerationCube");

		SolutionTiles = new List<GameObject>();

		//placeholder evolution levels
		easyEvolutions = 5;
		mediumEvolutions = 11;
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
		//select the proper theme
		randomTheme = (Theme)Random.Range (0, 2);

		//set gameload to false
		gameLoaded = false;

		//load game control object
		gameController = (GameObject)(Instantiate (Resources.Load("GameControlObject"), Vector3.zero, Quaternion.identity));

		ResetSolution();
	
	}
	
	// Update is called once per frame
	void Update ()
	{

        //check against game already having loaded
        if (!gameLoaded)
        {
            GameLoad();
        }
	}

	public void CreateCube(Vector3 position)
	{
		SolutionTiles.Add(Instantiate(GenerationCube, position, Quaternion.identity));
	}

	public void DestroyCube(GameObject gameObject)
	{
		SolutionTiles.Remove (gameObject);
	}

	//creates solution for the puzzles
	public void CreateSolution()
	{

		//afterloop is done, create solution
		//generates the solution grid
		for (int i = SolutionTiles.Count - 1; i > -1; i--) {

			//add the solution tile to the list

			GameObject SolutionGridInstance = (GameObject)Resources.Load ("SolutionGrid");



			//add a solution grid piece to the solution list
			gameController.GetComponent<GameLoopScript>().solutionList.Add(Instantiate(SolutionGridInstance, new Vector3 (SolutionTiles [i].transform.position.x, 0, SolutionTiles [i].transform.position.z), Quaternion.identity));

			SolutionTiles [i].GetComponent<GenerationTileScript> ().Destroy ();
			SolutionTiles.RemoveAt (i);
		}

		foreach (GameObject solutionTile in SolutionTiles) {
			solutionTile.GetComponent<GenerationTileScript> ().Destroy ();
		}
		//create the solution tiles from the finished solution

		//clear all solutions
		SolutionTiles.Clear ();

        //game has loaded
        gameLoaded = true;
	}

	public void GeneratePuzzle()
	{
		//evoluton testing script
		//WORkING PUZZLE GENERATION SCRIPT

		testCounter += .4f;
		//evolution testing script

		if (testCounter > 1.2f){

			if (evolutionCounter < evolutionRequirement) {

				bool wasToggled = false;


				if (!wasToggled) {

					//creates new random
					newRandomCubeInt = Random.Range (0, SolutionTiles.Count);


                    //checks both previous entries
					if (randomCheck != newRandomCubeInt) {
						SolutionTiles [newRandomCubeInt].GetComponent<GenerationTileScript> ().Toggle ();
						wasToggled = true;
						evolutionCounter++;
					} else {

					}
				}

                //set last cube to current
				randomCheck = newRandomCubeInt;

				testCounter = 0;
			} else {
				solutionCreated = false;
			}
		}

		if (!solutionCreated) {
			CreateSolution ();

			//create game start tile
			solutionCreated = true;
            //make the game active
            GameManagerScript.instance.gameActive = true;
        }

		//end of puzzle generation script
	}

	public void ResetSolution()
	{

		evolutionCounter = 0;
		evolutionRequirement = mediumEvolutions;
		solutionCreated = true;
	}

	public void GameLoad()
	{
		//evoluton testing script
		//WORkING PUZZLE GENERATION SCRIPT

		GeneratePuzzle();
		//end of puzzle generation script

	}


	//theme selector
	public Theme CurrentTheme {
		get {return randomTheme; }
		set { randomTheme = value; }
	}
}
