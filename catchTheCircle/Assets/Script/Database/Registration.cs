using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Registration : MonoBehaviour
{

    public InputField firstnamefield;
    public InputField lastnamefield;

    public Button submitButton;

    string url = "http://localhost/dbconnect/register.php";

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {


        WWWForm form = new WWWForm();
        form.AddField("firstname", firstnamefield.text.ToString());
        form.AddField("lasttname", lastnamefield.text.ToString());

        Debug.Log(firstnamefield.text.ToString() + "ok");

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.isHttpError == false) // Si il n'y a pas d'erreur alors lance la scène
            {
                Debug.Log("User created successfully.");
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
            else // Sinon affiche un message d'erreur
            {
                Debug.Log("User creation failed. Error #" + www.error);
            }
        }

    }
    public void VerifyInputs()
    {
        submitButton.interactable = (firstnamefield.text.Length >= 10 && lastnamefield.text.Length >= 20 );
    }


}
