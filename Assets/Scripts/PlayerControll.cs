using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {

    [Range(1, 10)]
    public float jumpForce = 1;

    public float lockPos = 0;

    public short count=0;

    public Text score;
    public GameObject particle;

    private bool clierTrigger = true;

    private ParticleSystem par;
    private bool inAir = false;
    private bool pause = false;

    private void Awake()
    {
        par = particle.GetComponent<ParticleSystem>();
        par.Stop();
    }
    bool first = false;
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            clierTrigger = true;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            clierTrigger = true;
        }

        var speed = this.GetComponent<Rigidbody>().velocity.magnitude;
        if (speed <= 10 && !pause)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0.5f, 0f, 0f), ForceMode.Impulse);
        }
        this.transform.rotation = Quaternion.Euler(lockPos, lockPos, transform.rotation.eulerAngles.z);

        if (count != 1 && clierTrigger)
        {
            clierTrigger = false;
            count = 1;
            StartCoroutine(Jump(this.gameObject));
            inAir = true;
        }

        PlayerPrefs.SetInt("score", (int)this.transform.position.x);

        score.text = "" + (int)this.transform.position.x;

        if(inAir)
        {
            transform.Rotate(new Vector3(0f,0f, -1f) * Time.deltaTime * 500, Space.World);
        }

        
        if (speed > 10 || first)
        {
            
            StartCoroutine(GameOver(this.gameObject, speed));
            
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        count = 0;
        inAir = false;
        par.Play();
    }

    


    IEnumerator GameOver(GameObject obj, float speed)
    {
        first = true;
        if (speed < 3 && obj.GetComponent<Rigidbody>().isKinematic == false)
        {
            pause = true;
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Boom").GetComponent<ParticleSystem>().Play();
            GameObject.FindGameObjectWithTag("GameOver").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("GameOverText").transform.GetChild(1).gameObject.SetActive(true);
            par.Stop();
        }
        yield return true;
    }

    public void restart()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.position = new Vector3(0f, 0f, 0f);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject del in objs)
        {
            Destroy(del);
        }
        first = false;
        GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<MapGenerator>().restart();
        GameObject.FindGameObjectWithTag("GameOver").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("GameOverText").transform.GetChild(1).gameObject.SetActive(false);
        pause = false;
    }

    
   IEnumerator Jump(GameObject obj)
    {
        par.Stop();
       
        obj.GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        yield return new WaitForSeconds(0.00001f);
        
    }


    

}
