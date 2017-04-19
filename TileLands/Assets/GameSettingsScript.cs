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

	public int GOLD_MEDALS_EARNED = 0;
	public int SILVER_MEDALS_EARNED = 0;
	public int BRONZE_MEDALS_EARNED = 0;
	public int TOTAL_TILES_TOGGLED = 0;

	public bool Muted = false;

	public int gameBorder = 5;



	// Use this for initialization
	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(transform.gameObject);
	}

	//loads game
	void Start () {

		//loads player data
		if (PlayerPrefs.HasKey ("Golds")) {
			GOLD_MEDALS_EARNED = PlayerPrefs.GetInt ("Golds");
		}
		if (PlayerPrefs.HasKey ("Silvers")) {
			SILVER_MEDALS_EARNED = PlayerPrefs.GetInt ("Silvers");
		}
		if (PlayerPrefs.HasKey ("Bronzes")) {
			BRONZE_MEDALS_EARNED = PlayerPrefs.GetInt ("Bronzes");
		}
		if (PlayerPrefs.HasKey ("TilesToggled")) {
			TOTAL_TILES_TOGGLED = PlayerPrefs.GetInt ("TilesToggled");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveGame()
	{
		PlayerPrefs.SetInt ("Golds", GOLD_MEDALS_EARNED);
		PlayerPrefs.SetInt ("Silvers", SILVER_MEDALS_EARNED);
		PlayerPrefs.SetInt ("Bronzes", BRONZE_MEDALS_EARNED);
		PlayerPrefs.SetInt ("TilesToggled", TOTAL_TILES_TOGGLED);
	}


}
