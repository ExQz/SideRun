using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject groundPrefab;
    public GameObject generatePoint;
    public GameObject destroyPoint;

    private Vector3 lastGroundObj;
    private float lastObjScaleX;

    private void Start()
    {
        lastObjScaleX = 18f;
        lastGroundObj = groundPrefab.transform.position;
    }

    public void restart()
    {
        lastObjScaleX = 18f;
        GameObject newGround = (GameObject)Instantiate(groundPrefab);
        lastGroundObj = groundPrefab.transform.position;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update () {

        if (generatePoint.transform.position.x >= lastGroundObj.x)
        {
            float up;
            GameObject newGround = (GameObject)Instantiate(groundPrefab);
            do
            {
                up = Random.Range(-2.5f, 2.5f);
            } while (up < -0.3f && 0.3f < up);
            newGround.transform.position = lastGroundObj + new Vector3(lastObjScaleX, up, 0);
            lastGroundObj = newGround.transform.position;
            lastObjScaleX = newGround.transform.localScale.x;
        }


        
	}
}
