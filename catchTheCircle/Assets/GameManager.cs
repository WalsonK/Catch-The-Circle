using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1f;
    public float actualScore = 0f;

    public GameObject levelCompleteUI;
    public GameObject levelObjectifUI;

    public string obj;



    private void Start()
    {
        //Random objectif
        int objCase = Random.Range(0, 3);
        Debug.Log(objCase);
        switch (objCase)
        {
            default:
                obj = "Les Spheres !";
                FindObjectOfType<playerCollision>().objectifTag = "circle";
                break;

            case 0:
                obj = "Les Spheres !";
                FindObjectOfType<playerCollision>().objectifTag = "circle";
                break;
            case 1:
                obj = "Les Triangles !";
                FindObjectOfType<playerCollision>().objectifTag = "triangle";
                break;
            case 2:
                obj = "Les Cubes !";
                FindObjectOfType<playerCollision>().objectifTag = "cube";
                break;
        }


        //Lance l'animation de départ
        levelObjectifUI.SetActive(true);
        Debug.Log("Level Starting");
    }


    public void EndGame()
    {
        if(gameEnded == false)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            gameEnded = true;
            Debug.Log("GAME OVER !");
            Invoke("Restart", restartDelay);
        }
       
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void completeLevel()
    {
        levelCompleteUI.SetActive(true);
        Debug.Log("Level Complete !!");
    }
    
}
