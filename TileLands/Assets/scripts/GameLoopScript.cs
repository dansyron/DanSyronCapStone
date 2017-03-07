using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class GameLoopScript : MonoBehaviour {

    public static GameLoopScript instance;

    GameObject sunLight;
    GameObject ocean;
    GameObject EnvironmentPlane;
    GameObject gameCube;
    GameObject firework;
	GameObject endingInterface;
	GameObject completionInterface;

    bool solved1;
	bool solved2;
    bool fireworkTriggered = false;
	bool fadeTriggered = false;
    bool fireworkFinished = false;
    bool resettingMoves;
	public bool transitioningStage;
	public bool transitioningToMainMenu;
    public bool rotatingCameraLeft;
	public bool rotatingCameraRight;

	public int turns;

    int fireworkTimer;
	float nextStageCounter;
	float returnToMenuCounter;
    float endgameCameraRotation;

    float cameraRotationValue;

    public List<GameObject> solutionList;
    public List<GameObject> activeCubeList;

    float randomLightangle;

    // Use this for initialization
    void Start() {

		//set turns to 0.
		turns = 0;
	

		//event trigger for UI elements
		GameWon = false;
		transitioningStage = false;
		transitioningToMainMenu = false;

        endgameCameraRotation = 0f;
        fireworkTimer = 0;
        cameraRotationValue = 0;

		//counter for proceeding to the next stage
		nextStageCounter = 0;
		returnToMenuCounter = 0;

        resettingMoves = false;
        rotatingCameraLeft = false;
		rotatingCameraRight = false;

        //puzzle isnt solved
        solved1 = false;
		solved2 = false;

        //create instance of this object
        instance = this;

        //calculate random sunlight angle.
        randomLightangle = (float)(Random.Range(-80, 81));

        //create the new solution list
        solutionList = new List<GameObject>();

        //list of all active cubes
        activeCubeList = new List<GameObject>();


        sunLight = (GameObject)Instantiate(Resources.Load("Lights/SunLightObject"), Vector3.zero, Quaternion.identity);
        sunLight.transform.Rotate(new Vector3(90f, 0, 0));


		//CREATE THE DIFFERENT PLACES FOR DIFFERNT THEMES
		if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Ocean) {

			/// 
			//create ocean;
			ocean = Resources.Load<GameObject>("OceanPlane");

			//play ocean ambient
			AudioManager.Instance.PlayOceanSound ();

		} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Desert) {
			/// 
			//create ocean;
			ocean = Resources.Load<GameObject>("DesertPlane");

			AudioManager.Instance.PlayDesertSound ();	
		}

		//play island sound
		else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.DesertIsland) {

			/// 
			//create ocean;
			ocean = Resources.Load<GameObject>("OceanPlane");

			//play Island ambient
			AudioManager.Instance.PlayOceanSound ();
		}

		//////////////

        //create ocean plane or other object.
        EnvironmentPlane = (GameObject)Instantiate(ocean, Vector3.zero, Quaternion.identity);

        gameCube = Resources.Load<GameObject>("BasicTile");

        //create the new start tile
        //startTile = (GameObject)(Instantiate (Resources.Load ("BasicTile"), Vector3.zero, Quaternion.identity));

        CreateCube(Vector3.zero);

		GameWon = false;
    }

    // Update is called once per frame
    void Update() {


        //only check for solution if the game is active.
        if (GameManagerScript.instance.gameActive)
        {
            //solution checker
            solved1 = solutionList.All(s => activeCubeList.Any(a => a.transform.position == s.transform.position));
			solved2 = activeCubeList.All(s => solutionList.Any(a => a.transform.position == s.transform.position));
        }

        //temporary solve flag
        if (solved1 && solved2)
        {
			GameWon = true;

			//destroy the game canvas interface.
			Destroy(PuzzleGeneratorScript.instance.GetComponent<PuzzleGeneratorScript>().gameInterface);

			//force settling on all cube objects.
			foreach (GameObject activeCube in activeCubeList) {
				if (activeCube.GetComponentInChildren<TIleRiseScript> () != null) {
					activeCube.GetComponentInChildren<TIleRiseScript> ().Settling = true;
					activeCube.GetComponentInChildren<TIleRiseScript> ().StartSettle ();
				}
			}

			foreach (GameObject solutionGrid in solutionList) {
				Destroy (solutionGrid);
			}

            //deactivate game
            GameManagerScript.instance.gameActive = false;

            if (!fireworkTriggered)
            {
				AudioManager.Instance.PlayFirework ();
                //make a new firework
                firework = (GameObject)Instantiate(Resources.Load("Effects/VictoryParticle"), Vector3.zero, Quaternion.identity);
                fireworkTriggered = true;

				//instantiates the end gamvas
				completionInterface = (GameObject)Instantiate(Resources.Load ("CompletionCanvas"), Vector3.zero, Quaternion.identity);
				completionInterface.GetComponent<Canvas> ().worldCamera = GameManagerScript.instance.mainCamera.GetComponent<Camera>();
            }

            if (endgameCameraRotation < .5f)
            {
                endgameCameraRotation += .01f;
            }

            GameManagerScript.instance.mainCamera.transform.Rotate(new Vector3(0, endgameCameraRotation, 0));


			//code that enables the stage transition
			if (transitioningStage) {
				nextStageCounter += .1f;
				endingInterface = (GameObject)Instantiate(Resources.Load ("EndingCanvas"), Vector3.zero, Quaternion.identity);
				endingInterface.GetComponent<Canvas> ().worldCamera = GameManagerScript.instance.mainCamera.GetComponent<Camera>();

				//reset stage
				if (nextStageCounter > 1.2) {
					ResetGameScene ();
				}
			}

			//code that enables the stage transition
			if (transitioningToMainMenu) {
				returnToMenuCounter += .1f;
				endingInterface = (GameObject)Instantiate(Resources.Load ("EndingCanvas"), Vector3.zero, Quaternion.identity);
				endingInterface.GetComponent<Canvas> ().worldCamera = GameManagerScript.instance.mainCamera.GetComponent<Camera>();

				//reset stage
				if (returnToMenuCounter > 1.2) {
					returnToMenuCounter = 0;
					SceneManager.LoadScene("MainMenuScene");
				}
			}
        }


        if (GameManagerScript.instance.gameActive)
        {
            //to restart the game, use this command
            //do input manager later
				

            //enable the move resetter
            if (resettingMoves)
            {
                ResetMoves();
            }

            //enable camera rotation
            if (rotatingCameraLeft  && ! rotatingCameraRight)
            {
                RotateCameraLeft();
            }

			//enable camera rotation
			if (rotatingCameraRight && ! rotatingCameraLeft)
			{
				RotateCameraRight();
			}
        }
			

    }

    public void ResetGameScene()
    {

        SceneManager.LoadScene("Tile Test Scene");
    }

	public void ReturnToMainMenu()
	{
		transitioningToMainMenu = true;

	}


    public void CreateCube(Vector3 position)
    {
        activeCubeList.Add(Instantiate(gameCube, position, Quaternion.identity));
    }

    public void ResetMoves()
    {
        foreach (GameObject gameObject in activeCubeList)
        {
            Destroy(gameObject);
        }
        activeCubeList.Clear();

        //create new cube
        CreateCube(Vector3.zero);

        resettingMoves = false;

		//reset turns
		turns = 0;
    }

    public void RotateCameraLeft()
    {

        if (cameraRotationValue < 30)
        {
			cameraRotationValue += 1;
			GameManagerScript.instance.mainCamera.transform.Rotate(new Vector3(0, 3 , 0));
        }
        else
        {
            cameraRotationValue = 0;
            rotatingCameraLeft = false;
        }

    }

	public void RotateCameraRight()
	{

		if (cameraRotationValue < 30)
		{
			cameraRotationValue += 1;
			GameManagerScript.instance.mainCamera.transform.Rotate(new Vector3(0,  -3 , 0));
		}
		else
		{
			cameraRotationValue = 0;
			rotatingCameraRight = false;
		}

	}

	public void CameraIsRotatingRight()
	{
		rotatingCameraRight = true;
		rotatingCameraLeft = false;
	}

	public void CameraIsRotatingLeft()
	{
		rotatingCameraLeft = true;
		rotatingCameraRight = false;
	}

	//proceed to the next stage 
	public void GoToNextStage()
	{
		transitioningStage = true;
	}

	//proceed to the next stage 
	public void GoToMainMenu()
	{
		transitioningStage = true;
	}

	public bool GameWon {
		get;
		set;
	}
}
