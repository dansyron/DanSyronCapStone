using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsScript : MonoBehaviour {

	public static GameSettingsScript instance;

	//assigned difficulty
	public int setDifficulty;

	public int EASY_EVOLUTIONS = 6;
	public int MED_EVOLUTIONS = 10;
	public int HARD_EVOLUTIONS = 15;
	public int EXPERT_EVOLUTIONS = 25;
	public int MASTER_EVOLUTIONS = 40;


	public int gameBorder = 4;

	public int TOTAL_TILES_TOGGLED;
	public int WINS;

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
		instance = this;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
