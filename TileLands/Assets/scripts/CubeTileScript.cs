using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTileScript : MonoBehaviour {

	Vector3 currentPosition;
	Vector3 temporaryPosition1;
	Vector3 temporaryPosition2;
	Vector3 temporaryPosition3;
	Vector3 temporaryPosition4;

	// Use this for initialization
	void Start () 
	{
		transform.localScale = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update ()

	{
		if (transform.localScale.x < 1) 
		{
			transform.localScale += new Vector3 (.1f, .1f, .1f);
		}
	}

	void OnTriggerStay(Collider collision) 
	{
		Debug.Log("collided");
		if (collision.gameObject.tag == "Tile") {
			//Destroy (collision.gameObject);
			Destroy (gameObject);
		}
	}

	void OnMouseDown()
	{
		//on mouse click, create a new cube tile
		if (Input.GetMouseButtonDown (0)) {

			currentPosition = transform.position;
			temporaryPosition1 = new Vector3 (currentPosition.x + 1, currentPosition.y, currentPosition.z);
			temporaryPosition2 = new Vector3 (currentPosition.x - 1, currentPosition.y, currentPosition.z);
			temporaryPosition3 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z + 1);
			temporaryPosition4 = new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z - 1);

			//instantiate new cubes
			Instantiate(Resources.Load("BasicTile"), temporaryPosition1, Quaternion.identity);
			Instantiate(Resources.Load("BasicTile"), temporaryPosition2, Quaternion.identity);
			Instantiate(Resources.Load("BasicTile"), temporaryPosition3, Quaternion.identity);
			Instantiate(Resources.Load("BasicTile"), temporaryPosition4, Quaternion.identity);
		

			temporaryPosition1 = currentPosition;
			temporaryPosition2 = currentPosition;
			temporaryPosition3 = currentPosition;
			temporaryPosition4 = currentPosition;
		}
			
	}
}
