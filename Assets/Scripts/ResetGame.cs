using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour {

    private void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>().restart();
    }
}
