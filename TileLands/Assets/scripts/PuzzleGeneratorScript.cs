using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGeneratorScript : MonoBehaviour {

	List<GameObject> SolutionTiles;
	Vector3 currentPosition;
	GameObject GenerationCube;
	GameObject gameController;
	public static PuzzleGeneratorScript instance;

	public GameObject gameInterface;

	int easyEvolutions;
	int mediumEvolutions;
	//int hardEvolutions;
	//int expertEvolutions;
	int randomCheck;
	int newRandomCubeInt;

	int border;

	bool gameLoaded;

	//selects a random game theme
	Theme randomTheme;

	float testCounter;

	bool gameReady;


	//controls the evolution count
	int evolutionCounter;
	int evolutionRequirement;


	// Use this for initialization
	void Start () 
	{

		border = 6;

		gameReady = false;

		SolutionGenerated = false;

		//create instance of this object
		instance = this;

		testCounter = 0;

		GenerationCube = Resources.Load<GameObject> ("GenerationCube");

		SolutionTiles = new List<GameObject>();

		//placeholder evolution levels
		easyEvolutions = 5;
		mediumEvolutions = 12;
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

			//remove nonfitting tiles BORDER
			if (Mathf.Abs (SolutionTiles [i].transform.position.x) <= border && Mathf.Abs (SolutionTiles [i].transform.position.y) <= border && Mathf.Abs (SolutionTiles [i].transform.position.z) <= border) {
				//add a solution grid piece to the solution list
				gameController.GetComponent<GameLoopScript> ().solutionList.Add (Instantiate (SolutionGridInstance, new Vector3 (SolutionTiles [i].transform.position.x, 0, SolutionTiles [i].transform.position.z), Quaternion.identity));
			}

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

		testCounter += 1 * Time.fixedDeltaTime;
		//evolution testing script

		Debug.Log (testCounter);

		if (testCounter > .05f){

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
				SolutionGenerated = false;
			}
		}

		if (!SolutionGenerated) {
			CreateSolution ();

			//create game start tile
			SolutionGenerated = true;
            //make the game active
            GameManagerScript.instance.gameActive = true;

			//make game ready
			PuzzleGeneratorScript.instance.GameReady = true;

				//create game canvas
				gameInterface = (GameObject)Instantiate(Resources.Load ("GameCanvas"), Vector3.zero, Quaternion.identity);
				gameInterface.GetComponent<Canvas> ().worldCamera = GameManagerScript.instance.mainCamera.GetComponent<Camera>();
        }

		//end of puzzle generation script
	}

	public void ResetSolution()
	{

		evolutionCounter = 0;
		evolutionRequirement = mediumEvolutions;
		SolutionGenerated = true;
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

	public bool SolutionGenerated{
		get;
		private set;
	}

	//is the game ready
	public bool GameReady {
		get {return gameReady;}
		set {gameReady = value;}
	}
}
