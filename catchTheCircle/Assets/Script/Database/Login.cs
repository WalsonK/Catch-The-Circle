using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public GameObject dashboard;
    public InputField mailfield;
    public InputField passwordfield;


    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginManager());
    }

    IEnumerator LoginManager()
    {
        WWWForm form = new WWWForm();
        form.AddField("mail", mailfield.text.ToString());
        form.AddField("password", passwordfield.text.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/dbconnect/login.php", form))
        {
            //yield return www.SendWebRequest();
            yield return www.SendWebRequest();
            if (www.isNetworkError != true)
            {
                DbManager.mail = mailfield.text;
                DbManager.password = passwordfield.text;
            }
            else
            {
                Debug.Log("User login failed. Error #" + www.error);
            }
        }
    }


    public void VerifyInputs()
    {
        submitButton.interactable = (mailfield.text.Length >= 8 && passwordfield.text.Length >= 8);
    }

}
