using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.HttpClient;
using UnityEngine.UI;
using SimpleJSON;
using TMPro;
using UnityEngine.Networking;

public class Login : MonoBehaviour {

    public TMP_InputField username;
    public TMP_InputField pass;

	public void login()
    {
        //localhost: 123 / api / login
        HttpClient client = new HttpClient();

        string line = "{ \"nick\":\"" + username.text + "\", \"pass\":\"" + pass.text + "\"}";

        StringContent loginInfo = new StringContent(line);

        Debug.Log(line);

        client.Post(new System.Uri("http://localhost:3000/api/login"),loginInfo, HttpCompletionOption.AllResponseContent, (r) =>
        {
            Debug.Log(r.StatusCode);
        });

    }


    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
