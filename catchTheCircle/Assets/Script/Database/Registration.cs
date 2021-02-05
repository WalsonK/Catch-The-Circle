using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Registration : MonoBehaviour
{
    public GameObject playermenu;
    public GameObject dashboard;

    public InputField mailfield;
    public InputField passwordfield;
    public InputField firstnamefield;
    public InputField lastnamefield;
    
    public Button submitButton;

    public void CallRegister()
    {
        if (playermenu.activeSelf == true)
        {
            StartCoroutine(Register());
        }
        /*
        else
        {
            Login();
        }
        */
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("firstname", firstnamefield.text.ToString());
        form.AddField("lastname", lastnamefield.text.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/dbconnect/register.php", form))
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
        submitButton.interactable = (firstnamefield.text.Length >= 3 && lastnamefield.text.Length >= 5 );
    }

    /*
    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("mail", mailfield.text.ToString());
        form.AddField("password", passwordfield.text.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/dbconnect/login.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isHttpError == false) // Si il n'y a pas d'erreur alors lance la scène
            {
                gameObject.SetActive(false); // Cache le menu de connexion
                dashboard.SetActive(true); // Affiche le dashboard
                Debug.Log("User loged in successfully.");
            }
            else // Sinon affiche un message d'erreur
            {
                Debug.Log("User login failed . Error #" + www.error);
            }
        }

    }
    */
}
