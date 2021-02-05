using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class webtest : MonoBehaviour
{
        void Start()
        {
            StartCoroutine(GetText());
        }

        IEnumerator GetText()
        {
            UnityWebRequest www = UnityWebRequest.Get("http://localhost/dbconnect/webtest.php");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
            // Show results as text
            string[] webResults = www.downloadHandler.text.Split('\t');
            Debug.Log(webResults[0]);
            }
        }

    // Start is called before the first frame update
    /*
    IEnumerator Start()
    {
        UnityWebRequest www = new UnityWebRequest ("http://localhost/dbconnect/webtest.php");
        yield return www.SendWebRequest() ;
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                string[] webResults = www.downloadHandler.text.Split('\t');
                //Show results as text
                Debug.Log(webResults[0]);

                int webNumb = int.Parse(webResults[1]); // 2eme partie du echo
                webNumb *= 2; //double
                Debug.Log(webNumb);
            }

    }
    */

}
