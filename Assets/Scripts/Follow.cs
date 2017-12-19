using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void Update () { // 1.01 -0.79 0  4.65 -5 0
        this.transform.position = player.transform.position + new Vector3(3.64f, -4.21f, 0);
	}
}
