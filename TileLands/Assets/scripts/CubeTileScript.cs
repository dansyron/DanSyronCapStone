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

	int border;

    int skinRandomizer;

    // Use this for initialization
    void Start()
    {
		//establishes game border
		border = 6;

        transform.localScale = new Vector3(1f, 1f, 1f);

        //if cube collides with any object from the cube list
		if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Ocean) {
			//pick the forest skins
			PickForestSkins ();
		} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Desert) {
			PickDesertSkins ();
		} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.DesertIsland) {
			PickIslandSkins ();
		}
			PickIncorrectSkin ();

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

		//make rising true
        int randomRotation = Random.Range(0, 3);
        tileFacade.transform.Rotate(new Vector3(0, 90f * randomRotation, 0));

        //skin replace trigger
        skinReplaced = false;


        //create ripple on instance
			ripple = Instantiate (rippleEffect, new Vector3 (transform.position.x, -1.36f, transform.position.z), Quaternion.identity);


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
				ripple = Instantiate (rippleEffect, new Vector3 (transform.position.x, -.4f, transform.position.z), Quaternion.identity);
		

			//possible source of error
			//tileFacade.transform.SetParent (null);

			//tileFacade.GetComponent<TIleRiseScript> ().StartFall ();

            //destroy object
			Destroy();
        }

        //if not on a solution tile, create the lava skin for that tile
        if (collision.gameObject.tag == "SolutionTile")
        {
			if (!skinReplaced) {
				//destroy current skin
				Destroy (tileFacade);

				//if there is no tile parent

				//if cube collides with any object from the cube list
				if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Ocean) {
					//pick the forest skins
					PickForestSkins ();
				} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Desert) {
					PickDesertSkins ();
				} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.DesertIsland) {
					PickIslandSkins ();


				}

					
				tileFacade = Instantiate (tileSkin, transform.position, Quaternion.identity);
				tileFacade.transform.SetParent (transform);
				int randomRotation = Random.Range (0, 3);
				tileFacade.transform.Rotate (new Vector3 (0, 90f * randomRotation, 0));


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
			if (Input.GetMouseButtonDown (0)) {
				//increase turns

				//create the proper sound
				//create proper sound
				//if cube collides with any object from the cube list
				if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Ocean || PuzzleGeneratorScript.instance.CurrentTheme == Theme.DesertIsland) {
					//pick the forest skins
					AudioManager.Instance.PlaySplash();
				} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Desert) {
					AudioManager.Instance.PlayRockCrunch();
				}
					
				GameLoopScript.instance.GetComponent<GameLoopScript> ().turns++;

				Vector3 currentPosition = transform.position;
				temporaryPosition1 = new Vector3 (currentPosition.x + 1, currentPosition.y, currentPosition.z);
				temporaryPosition2 = new Vector3 (currentPosition.x - 1, currentPosition.y, currentPosition.z);
				temporaryPosition3 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z + 1);
				temporaryPosition4 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z - 1);

				//only make blocks within the constraints
				if (Mathf.Abs (temporaryPosition1.x) <= border && Mathf.Abs (temporaryPosition1.y) <= border && Mathf.Abs (temporaryPosition1.z) <= border) {
					GameLoopScript.instance.CreateCube (temporaryPosition1);
					temporaryPosition1 = currentPosition;
				}

				if (Mathf.Abs (temporaryPosition2.x) <= border && Mathf.Abs (temporaryPosition2.y) <= border && Mathf.Abs (temporaryPosition2.z) <= border) {
					GameLoopScript.instance.CreateCube (temporaryPosition2);
					temporaryPosition2 = currentPosition;
				}

				if (Mathf.Abs (temporaryPosition3.x) <= border && Mathf.Abs (temporaryPosition3.y) <= 8 && Mathf.Abs (temporaryPosition3.z) <= border) {
					GameLoopScript.instance.CreateCube (temporaryPosition3);
					temporaryPosition3 = currentPosition;
				}

				if (Mathf.Abs (temporaryPosition4.x) <= border && Mathf.Abs (temporaryPosition4.y) <= 8 && Mathf.Abs (temporaryPosition4.z) <= border) {
					GameLoopScript.instance.CreateCube (temporaryPosition4);
					temporaryPosition4 = currentPosition;
				}

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

		skinRandomizer = Random.Range(0, 13);
		rippleEffect = (GameObject)Resources.Load("Effects/TileDust");

		switch (skinRandomizer)
		{
		case 0:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert01");
			}
			break;
		case 1:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert02");
			}
			break;
		case 2:
			{
				tileSkin = (GameObject)(Resources.Load("GameTiles/Desert/Desert03"));
			}
			break;
		case 3:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert04");
			}
			break;
		case 4:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert05");
			}
			break;
		case 5:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert06");
			}
			break;
		case 6:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert07");
			}
			break;
		case 7:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert08");
			}
			break;
		case 8:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert09");
			}
			break;
		case 9:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert10");
			}
			break;
		case 10:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert11");
			}
			break;
		case 11:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert12");
			}
			break;
		case 12:
			{
				tileSkin = (GameObject)Resources.Load("GameTiles/Desert/Desert13");
			}
			break;

		}
	}

	//desertisland skins
	void PickIslandSkins()
	{
		{

			skinRandomizer = Random.Range(0, 13);
			rippleEffect = (GameObject)Resources.Load("Effects/TileRipples");

			switch (skinRandomizer)
			{
			case 0:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island01");
				}
				break;
			case 1:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island02");
				}
				break;
			case 2:
				{
					tileSkin = (GameObject)(Resources.Load("GameTiles/Island/Island03"));
				}
				break;
			case 3:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island04");
				}
				break;
			case 4:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island05");
				}
				break;
			case 5:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island06");
				}
				break;
			case 6:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island07");
				}
				break;
			case 7:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island08");
				}
				break;
			case 8:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island09");
				}
				break;
			case 9:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island10");
				}
				break;
			case 10:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island11");
				}
				break;
			case 11:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island12");
				}
				break;
			case 12:
				{
					tileSkin = (GameObject)Resources.Load("GameTiles/Island/Island13");
				}
				break;

			}
		}
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
		if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Ocean || PuzzleGeneratorScript.instance.CurrentTheme == Theme.DesertIsland) {
			rippleEffect = (GameObject)Resources.Load("Effects/TileRipples");
		} else if (PuzzleGeneratorScript.instance.CurrentTheme == Theme.Desert) {
			rippleEffect = (GameObject)Resources.Load("Effects/TileDust");
		}


        tileSkin = (GameObject)Resources.Load("GameTiles/IncorrectTile");
    }

	void Destroy()
	{

		//possible source of error
		tileFacade.transform.SetParent (null);

		tileFacade.GetComponent<TIleRiseScript> ().Falling = true;

		tileFacade.GetComponent<TIleRiseScript> ().StartFall ();

		//remove current cube from list
		GameLoopScript.instance.activeCubeList.Remove(gameObject);

		Destroy (gameObject);
	}

}
