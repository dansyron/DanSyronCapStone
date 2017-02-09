using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//insert all constants here for the game    
public enum Theme {Ocean = 0, Desert = 1, DesertIsland = 2, Ice = 3, Lava = 4, Space = 5};

public class Constants : MonoBehaviour {

	public static Constants instance;

	//difficulty tiers;
	public int EASY_EVOLUTIONS = 6;
	public int MEDIUM_EVOLUTIONS = 11;
	public int HARD_EVOLUTIONS = 18;
	public int EXPERT_EVOLUTIONS = 25;
	public int MASTER_EVOLUTIONS = 30;
}
