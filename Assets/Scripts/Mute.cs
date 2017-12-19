using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("Music",1)==1)
        {
            this.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            this.GetComponent<AudioSource>().mute = true;
        }
	}
}
