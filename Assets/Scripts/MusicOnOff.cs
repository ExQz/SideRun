using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnOff : MonoBehaviour {

    private void OnMouseDown()
    {
        if(PlayerPrefs.GetInt("Music",1) == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
           
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
