﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceene : MonoBehaviour {

    public GameObject music;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(music);
        SceneManager.LoadScene("Menu");
	}
	
	
}
