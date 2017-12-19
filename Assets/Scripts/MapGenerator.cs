using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject groundPrefab;
    public GameObject backgroundPefab;
    public GameObject trianglePrefab;
    public GameObject generatePoint;


    private Vector3 lastBackGroundObj;
    private Vector3 lastGroundObj;
    private float lastObjScaleX;

    private short down, up;

    private void Start()
    {

        trianglePrefab.AddComponent<Rigidbody>();
        trianglePrefab.GetComponent<Rigidbody>().isKinematic = true;
        trianglePrefab.GetComponent<Rigidbody>().useGravity = false;
        trianglePrefab.GetComponent<MeshCollider>().convex = true;
        //trianglePrefab.GetComponent<MeshCollider>().isTrigger = true;

        down = 0;
        up = 0;
        lastObjScaleX = 18f;
        lastBackGroundObj = backgroundPefab.transform.position;
        lastGroundObj = groundPrefab.transform.position;
    }

    public void restart()
    {
        lastObjScaleX = 18f;
        GameObject newGround = (GameObject)Instantiate(groundPrefab);
        lastGroundObj = groundPrefab.transform.position;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        GameObject[] temp = GameObject.FindGameObjectsWithTag("BackGround");

        foreach (GameObject del in temp)
        {
            Destroy(del);
        }

        GameObject newBackground = (GameObject)Instantiate(backgroundPefab);

        lastBackGroundObj = backgroundPefab.transform.position;
    }

    // Update is called once per frame
    void Update () {

        if (generatePoint.transform.position.x >= lastGroundObj.x)
        {
            float y;
            GameObject newGround = (GameObject)Instantiate(groundPrefab);
            do
            {
                y = generteNumber();

                if (y == -1)
                {
                    down++;
                    newGround.transform.position = lastGroundObj + new Vector3(lastObjScaleX, -1.5f, 0);
                    up = 0;
                }
                else if (y == 1)
                {
                    up++;
                    newGround.transform.position = lastGroundObj + new Vector3(lastObjScaleX, 1.5f, 0);
                    down = 0;
                }
            } while (up > 2 || down > 2);

            
            //newGround.transform.position = lastGroundObj + new Vector3(lastObjScaleX, 1.5f, 0);
            lastGroundObj = newGround.transform.position;
            lastObjScaleX = newGround.transform.localScale.x;
        }

        if(generatePoint.transform.position.x >= lastBackGroundObj.x)
        {
            GameObject newBackground = (GameObject)Instantiate(backgroundPefab);

            newBackground.transform.position = lastBackGroundObj + new Vector3(40f, 0f, 0f);
            lastBackGroundObj = newBackground.transform.position;
        }
	}

    float generteNumber()
    {
        int y;
        int x = 1;
        y = (int) Random.Range(1,10);

        if(y <=5)
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        return x;
    }
}
