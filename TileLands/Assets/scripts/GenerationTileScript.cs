using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationTileScript : MonoBehaviour {

	Vector3 currentPosition;
	Vector3 temporaryPosition1;
	Vector3 temporaryPosition2;
	Vector3 temporaryPosition3;
	Vector3 temporaryPosition4;

	// Use this for initialization
	void Start () 
	{
		transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Update is called once per frame
	void Update ()

	{ 

	}

	void OnTriggerStay(Collider collision) 
	{
		if (collision.gameObject.tag == "Tile") {
			//Destroy (collision.gameObject);
			PuzzleGeneratorScript.instance.DestroyCube(gameObject);
			Destroy (gameObject);
		}
	}

	void OnMouseDown ()
	{
		//on mouse click, create a new cube tile
		if (Input.GetMouseButtonDown (0)) {

			currentPosition = transform.position;
			temporaryPosition1 = new Vector3 (currentPosition.x + 1, currentPosition.y, currentPosition.z);
			temporaryPosition2 = new Vector3 (currentPosition.x - 1, currentPosition.y, currentPosition.z);
			temporaryPosition3 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z + 1);
			temporaryPosition4 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z - 1);

			//instantiate new cubes

			PuzzleGeneratorScript.instance.CreateCube (temporaryPosition1);

			PuzzleGeneratorScript.instance.CreateCube (temporaryPosition2);

			PuzzleGeneratorScript.instance.CreateCube (temporaryPosition3);

			PuzzleGeneratorScript.instance.CreateCube (temporaryPosition4);

			//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition1, Quaternion.identity);
			//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition2, Quaternion.identity);
			//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition3, Quaternion.identity);
			//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition4, Quaternion.identity);

			//reset temp positions.
			temporaryPosition1 = currentPosition;
			temporaryPosition2 = currentPosition;
			temporaryPosition3 = currentPosition;
			temporaryPosition4 = currentPosition;
		}

	}

	public void Toggle()
	{
		currentPosition = transform.position;
		temporaryPosition1 = new Vector3 (currentPosition.x + 1, currentPosition.y, currentPosition.z);
		temporaryPosition2 = new Vector3 (currentPosition.x - 1, currentPosition.y, currentPosition.z);
		temporaryPosition3 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z + 1);
		temporaryPosition4 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z - 1);

		//instantiate new cubes

		PuzzleGeneratorScript.instance.CreateCube (temporaryPosition1);

		PuzzleGeneratorScript.instance.CreateCube (temporaryPosition2);

		PuzzleGeneratorScript.instance.CreateCube (temporaryPosition3);

		PuzzleGeneratorScript.instance.CreateCube (temporaryPosition4);

		//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition1, Quaternion.identity);
		//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition2, Quaternion.identity);
		//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition3, Quaternion.identity);
		//Instantiate (Resources.Load ("GenerationCube"), temporaryPosition4, Quaternion.identity);

		//reset temp positions.
		temporaryPosition1 = currentPosition;
		temporaryPosition2 = currentPosition;
		temporaryPosition3 = currentPosition;
		temporaryPosition4 = currentPosition;
	}

	public void AddSolutionTiles ()
	{
		Instantiate (Resources.Load ("SolutionGrid"), currentPosition, Quaternion.identity);
	}

	public void Destroy()
	{
		Destroy (gameObject);
	}
}
		

