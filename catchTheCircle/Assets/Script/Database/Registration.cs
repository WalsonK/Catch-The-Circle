using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Registration : MonoBehaviour
{
    /*
    public InputField firstnamefield;
    public InputField lastnamefield;
    public Button submitButton;
    */

    string registerFirstname = "";
    string registerLastname = "";
    string errorMessage = "";
    bool isWorking = false;
    bool registrationCompleted = false;


    public void CallRegister()
    {
        StartCoroutine(RegisterEnumerator());
    }


    IEnumerator RegisterEnumerator()
    {
        isWorking = true;
        registrationCompleted = false;
        errorMessage = "";

        WWWForm form = new WWWForm();
        form.AddField("firstname", registerFirstname);
        form.AddField("lastname", registerLastname);


        using (UnityWebRequest www = UnityWebRequest.Post(rootURL + "register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                errorMessage = www.error;
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("Success"))
                {
                    ResetValues();
                    registrationCompleted = true;
                    currentWindow = CurrentWindow.Login;
                }
                else
                {
                    errorMessage = responseText;
                }
            }
        }

        isWorking = false;
    }

    /*
    IEnumerator Register()
    {
        string url = "http://localhost/sqlconnect/register.php";

        WWWForm form = new WWWForm();
        form.AddField("firstname", firstnamefield.text);
        form.AddField("lasttname", lastnamefield.text);

        UnityWebRequest uwr = new UnityWebRequest(url);
        yield return uwr;
        if (uwr.isHttpError == false) // Si il n'y a pas d'erreur alors lance la scène
        {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else // Sinon affiche un message d'erreur
        {
            Debug.Log("User creation failed. Error #" + uwr.error);
        }
    }
    */

    public void VerifyInputs()
    {
        submitButton.interactable = (firstnamefield.text.Length >= 10 && lastnamefield.text.Length >= 20);
    }


}
