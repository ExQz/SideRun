using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        this.transform.parent.position = new Vector3(0f, 0f, 0f);
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Ground");
        foreach(GameObject del in obj)
        {
            Destroy(del);
        }
        GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<MapGenerator>().restart();
    }
}
