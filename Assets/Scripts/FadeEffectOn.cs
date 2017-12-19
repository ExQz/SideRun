using UnityEngine;
using System.Collections;

public class FadeEffectOn : MonoBehaviour {

    void Awake()
    {
        StartCoroutine(OnLevelLoad());
    }

    IEnumerator OnLevelLoad()
    {
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeEffect>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);

    }
}
