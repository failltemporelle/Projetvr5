using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class GetJson : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(GetRequest("https://localhost:7020/api/Dashboard/subscription"));
    }

    IEnumerator GetRequest(string uri)
    {
         using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            print(webRequest.downloadHandler.text);

            var N = JSON.Parse(webRequest.downloadHandler.text);

            string sub = N["value"][0]["subscriptionId"].Value;
            print(sub);
        }
    }
}