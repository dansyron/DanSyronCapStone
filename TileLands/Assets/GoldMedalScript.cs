using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMedalScript : MonoBehaviour {

	// Use this for initialization


		float alpha = 0;
		bool fading;
	    int GoldMoves;
	    int playerTurns;

	    float medalCounter = 0;

		// Use this for initialization
		void Start () {
			fading = true;
			GetComponent<CanvasGroup> ().alpha = alpha;
		GoldMoves = (int)(GameSettingsScript.instance.setDifficulty * 1.1);
		playerTurns = GameLoopScript.instance.GetComponent<GameLoopScript> ().turns;


		//award medal based on count:
		//add a gold medal
		if (playerTurns <= GoldMoves) {
			GameSettingsScript.instance.GOLD_MEDALS_EARNED += 1;
			GameSettingsScript.instance.SaveGame ();
		}

		}

		// Update is called once per frame
		void Update () {

		if (playerTurns <= GoldMoves) {
			medalCounter += 1 * Time.fixedDeltaTime;

			if (medalCounter > 1f) {
				if (fading) {
					if (alpha < 1) {
						alpha += .1f;
					} else
						fading = false;
					GetComponent<CanvasGroup> ().alpha = alpha;
				}
			}
		}



		}
}
