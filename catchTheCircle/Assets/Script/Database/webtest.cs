using System.Collections;
using UnityEngine;

public class webtest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW request = new WWW("http://localhost/dbconnect/webtest.php");
        yield return request;
        string[] webResults = request.text.Split('\t'); // Parse à chaque tab
        Debug.Log(webResults[0]);
        int webNumb = int.Parse(webResults[1]);
        webNumb *= 2; //double
        Debug.Log(webNumb);

    }

}
