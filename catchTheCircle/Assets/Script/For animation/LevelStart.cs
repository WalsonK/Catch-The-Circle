using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public GameObject theUI;
    public GameObject scoreUI;

    public void disableObjectifUI()
    {
        Debug.Log("Level Start, Take them !");
        theUI.SetActive(false);
        scoreUI.SetActive(true);
    }
}
