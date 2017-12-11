using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {
    public float lockPos = 0;

    public short triger=0;

    public Text score;

    private bool clierTrigger = true;



    // Update is called once per frame
    void Update () {

        var speed = this.GetComponent<Rigidbody>().velocity.magnitude;
        if (speed <= 10)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(25f, 0f, 0f), ForceMode.Impulse);
        }
        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);

        if (Input.GetKey(KeyCode.Space) && triger <2 && clierTrigger)
        {
            StartCoroutine(Jump(this.gameObject));
        }

        score.text = "Score: " + (int) this.transform.position.x;

	}


   IEnumerator Jump(GameObject obj)
    {
        clierTrigger = false;
        triger++;
        obj.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 350f, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        clierTrigger = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        triger = 0;
    }

}
