using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTileScript : MonoBehaviour {

    Vector3 temporaryPosition1;
    Vector3 temporaryPosition2;
    Vector3 temporaryPosition3;
    Vector3 temporaryPosition4;


    //designated tile skin.
    GameObject tileSkin;
    GameObject tileFacade;
    GameObject rippleEffect;
    GameObject ripple;

    bool skinReplaced;

    int skinRandomizer;

    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);

        //if cube collides with any object from the cube list
		if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Ocean) {
			//pick the forest skins
			PickForestSkins ();
		} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Desert) {
			
		}
        PickIncorrectSkin();

        Initialize();
    }

    void Initialize()
    {

        ////////////////////////////
        //establish the base skin
        /////////////////////////////

        //create the tile skins
        tileFacade = Instantiate(tileSkin, transform.position, Quaternion.identity);
        tileFacade.transform.SetParent(transform);
        int randomRotation = Random.Range(0, 3);
        tileFacade.transform.Rotate(new Vector3(0, 90f * randomRotation, 0));


        //skin replace trigger
        skinReplaced = false;



        //create ripple on instance
        ripple = Instantiate(rippleEffect, new Vector3(transform.position.x, -.4f, transform.position.z), Quaternion.identity);


    }

    // Update is called once per frame
    void Update()

    {
        if (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(.1f, .1f, .1f);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Tile") {
            //Destroy (collision.gameObject);

            //create ripple on instance
            ripple = Instantiate(rippleEffect, new Vector3(transform.position.x, -.4f, transform.position.z), Quaternion.identity);

            //remove current cube from list
            GameLoopScript.instance.activeCubeList.Remove(gameObject);

            //destroy object
            Destroy(tileFacade);
            Destroy(gameObject);
        }

        //if not on a solution tile, create the lava skin for that tile
        if (collision.gameObject.tag == "SolutionTile")
        {
            if (!skinReplaced)
            {
                //destroy current skin
                Destroy(tileFacade);



				//if cube collides with any object from the cube list
				if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Ocean) {
					//pick the forest skins
					PickForestSkins ();
				} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Desert) {

				}



                tileFacade = Instantiate(tileSkin, transform.position, Quaternion.identity);
                tileFacade.transform.SetParent(transform);
                int randomRotation = Random.Range(0, 3);
                tileFacade.transform.Rotate(new Vector3(0, 90f * randomRotation, 0));

                //skin was replaced
                skinReplaced = true;
            }
        }
    }

    void OnMouseDown()
    {
        //if game is active
        if (GameManagerScript.instance.gameActive)
        {
            //on mouse click, create a new cube tile
            if (Input.GetMouseButtonDown(0))
            {

                Vector3 currentPosition = transform.position;
                temporaryPosition1 = new Vector3(currentPosition.x + 1, currentPosition.y, currentPosition.z);
                temporaryPosition2 = new Vector3(currentPosition.x - 1, currentPosition.y, currentPosition.z);
                temporaryPosition3 = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 1);
                temporaryPosition4 = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - 1);

                //instantiate new cubes
                //Instantiate(Resources.Load("BasicTile"), temporaryPosition1, Quaternion.identity);
                //Instantiate(Resources.Load("BasicTile"), temporaryPosition2, Quaternion.identity);
                //Instantiate(Resources.Load("BasicTile"), temporaryPosition3, Quaternion.identity);
                //Instantiate(Resources.Load("BasicTile"), temporaryPosition4, Quaternion.identity);


                GameLoopScript.instance.CreateCube(temporaryPosition1);

                GameLoopScript.instance.CreateCube(temporaryPosition2);

                GameLoopScript.instance.CreateCube(temporaryPosition3);

                GameLoopScript.instance.CreateCube(temporaryPosition4);

                temporaryPosition1 = currentPosition;
                temporaryPosition2 = currentPosition;
                temporaryPosition3 = currentPosition;
                temporaryPosition4 = currentPosition;
            }
        }
    }
		
    //selects the random forest skins
    void PickForestSkins()
    {

        skinRandomizer = Random.Range(0, 13);
        rippleEffect = (GameObject)Resources.Load("Effects/TileRipples");

        switch (skinRandomizer)
        {
            case 0:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/GrassTile1");
                }
                break;
            case 1:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/GrassTile2");
                }
                break;
            case 2:
                {
                    tileSkin = (GameObject)(Resources.Load("GameTiles/Forest/GrassTile3"));
                }
                break;
            case 3:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/LampPost1");
                }
                break;
            case 4:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/SmallTreeTile1");
                }
                break;
            case 5:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/SmallTreeTile2");
                }
                break;
            case 6:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/TreeTile1");
                }
                break;
            case 7:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/TreeTile2");
                }
                break;
            case 8:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/TreeTile3");
                }
                break;
            case 9:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/TreeTile4");
                }
                break;
            case 10:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/CampSite1");
                }
                break;
            case 11:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/Rocks1");
                }
                break;
            case 12:
                {
                    tileSkin = (GameObject)Resources.Load("GameTiles/Forest/LargeTreeTile1");
                }
                break;

        }
    }

	//desert skins
	void PickDesertSkins()
	{

	}

	//desertisland skins
	void PickDesertIslandSkins()
	{

	}

	//lavaskins
	void PickLavaSkins()
	{

	}

	//iceskins
	void PickIceSkins()
	{

	}

    void PickIncorrectSkin()
    {
        rippleEffect = (GameObject)Resources.Load("Effects/TileRipples");

        tileSkin = (GameObject)Resources.Load("GameTiles/IncorrectTile");
    }

}
