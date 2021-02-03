
using UnityEngine;
using UnityEngine.UI;

public class Objectif : MonoBehaviour
{
    public Text objectif;

    // Update is called once per frame
    void Update()
    {
        objectif.text = FindObjectOfType<GameManager>().obj.ToString();
    }
}
