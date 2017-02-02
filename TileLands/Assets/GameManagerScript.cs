﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    public static GameManagerScript instance;

    GameObject puzzleGenerator;
    public GameObject mainCamera;
    public bool gameActive;
  

    // Use this for initialization
    void Start () {

        //create instance

        instance = this;
        //create the new puzzlegenerator

        mainCamera = (GameObject)Instantiate(Resources.Load("GameCamera"), Vector3.zero, Quaternion.identity);
        puzzleGenerator = (GameObject)Instantiate(Resources.Load("PuzzleGeneratorScript"), Vector3.zero, Quaternion.identity);

        gameActive = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
