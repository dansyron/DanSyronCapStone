using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleRiseScript : MonoBehaviour {

	float currentY;
	float riseValue;
	float settleValue;

	public bool Rising {
		get;
		set;
	}

	public bool Falling {
		get;
		set;
	}

	public bool Settling {
		get;
		set;
	}

	// Use this for initialization
	void Awake () {
		transform.position = new Vector3 (transform.position.x, -2f, transform.position.z);
		riseValue = 6f;
		settleValue = 1.5f;
		currentY = transform.position.y;
		Rising = true;
		Falling = false;
		Settling = false;
		Initialize ();
	}

	void Initialize()
	{
		StartRise ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator TileRise()
	{
		while (Rising) {
			if (currentY < 0) {
				currentY += riseValue * Time.fixedDeltaTime;
				transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
			} else {
				transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
				Rising = false;
			}
			yield return new WaitForFixedUpdate ();
		}
	}

		IEnumerator TileFall()
	{

		while (Falling) {
			
			Rising = false;

			if (currentY > -2) {
				currentY -= (float)(riseValue * 2) * Time.fixedDeltaTime;
				transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);

			} else {

				Destroy (gameObject);

			}
			yield return new WaitForFixedUpdate ();
		}
	}

	IEnumerator TileSettle()
	{
		//float randomSettleHeight = Random.Range (-.35f, 0f);
		Falling = false;
		Rising = false;

		while (Settling) {
			if (currentY > -1.3 || currentY < -1.4) {
				if (currentY > -1.3) {

					//script shake.
					int rumbleAmount = Random.Range(-2, 3);


					currentY -= settleValue * Time.fixedDeltaTime;
					transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
				} else {
					Settling = false;
				}

				if (currentY < -1.4) {

					currentY += settleValue * Time.fixedDeltaTime;
					transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
				} else {
					Settling = false;
				}

			}
			 else {

				Settling = false;
			}
			yield return new WaitForFixedUpdate ();
		}
	}

	public void StartRise()
	{
		StartCoroutine (TileRise());
	}

	public void StartFall()
	{
		StartCoroutine (TileFall());
	}

	public void StartSettle()
	{
		StartCoroutine (TileSettle());
	}

	//destroys prefab

		
}
