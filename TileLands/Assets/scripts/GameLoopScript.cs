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

    bool solved;
    bool fireworkTriggered = false;
    bool fireworkFinished = false;
    bool resettingMoves;
    bool rotatingCamera;


    int fireworkTimer;
    float endingTimer;
    float endgameCameraRotation;

    float cameraRotationValue;

    public List<GameObject> solutionList;
    public List<GameObject> activeCubeList;

    float randomLightangle;

    // Use this for initialization
    void Start() {

        endgameCameraRotation = 0f;
        fireworkTimer = 0;
        endingTimer = 0;
        cameraRotationValue = 0;

        resettingMoves = false;
        rotatingCamera = false;

        //puzzle isnt solved
        solved = false;

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

        //create ocean;
        ocean = Resources.Load<GameObject>("OceanPlane");
        //create ocean plane or other object.
        EnvironmentPlane = (GameObject)Instantiate(ocean, Vector3.zero, Quaternion.identity);

        gameCube = Resources.Load<GameObject>("BasicTile");

        //create the new start tile
        //startTile = (GameObject)(Instantiate (Resources.Load ("BasicTile"), Vector3.zero, Quaternion.identity));

        CreateCube(Vector3.zero);


    }

    // Update is called once per frame
    void Update() {

        //only check for solution if the game is active.
        if (GameManagerScript.instance.gameActive)
        {
            //solution checker
            solved = solutionList.All(s => activeCubeList.Any(a => a.transform.position == s.transform.position));
        }

        //temporary solve flag
        if (solved)
        {
            //deactivate game
            GameManagerScript.instance.gameActive = false;

            endingTimer += .01f;

            if (!fireworkTriggered)
            {
                //make a new firework
                firework = (GameObject)Instantiate(Resources.Load("Effects/VictoryParticle"), Vector3.zero, Quaternion.identity);
                fireworkTriggered = true;
            }

            if (endgameCameraRotation < .5f)
            {
                endgameCameraRotation += .01f;
            }

            GameManagerScript.instance.mainCamera.transform.Rotate(new Vector3(0, endgameCameraRotation, 0));

            if (endingTimer > 4)
            {
                ResetGameScene();
            }


        }


        if (GameManagerScript.instance.gameActive)
        {
            //to restart the game, use this command
            //do input manager later
            if (Input.GetKeyDown(KeyCode.R))
            {
                {

                    //restart scene
                    ResetGameScene();
                }
            }

            //if enter key is pressed, all tiles are reset.
            if (Input.GetKeyDown(KeyCode.U))
            {
                resettingMoves = true;
            }

            //for camera rotation.
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rotatingCamera = true;
            }

            //enable the move resetter
            if (resettingMoves)
            {
                ResetMoves();
            }

            //enable camera rotation
            if (rotatingCamera)
            {
                RotateCamera();
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
    }

    public void RotateCamera()
    {

        if (cameraRotationValue < 30)
        {
            cameraRotationValue += 1;
            GameManagerScript.instance.mainCamera.transform.Rotate(new Vector3(0, 3 , 0));
        }
        else
        {
            cameraRotationValue = 0;
            rotatingCamera = false;
        }

    }
}
