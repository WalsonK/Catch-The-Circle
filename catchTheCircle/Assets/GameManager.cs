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
    public bool difficult = true;
    public int objCase;



    private void Start()
    {
        difficult = true;
        if (difficult == true)
        {
            //Random objectif difficile
            objCase = Random.Range(0, 12);
        }
        else
        {
            //Random objectif facile
            objCase = Random.Range(0, 3);
        }

        Debug.Log(objCase);

        switch (objCase)
        {
            default:
                obj = "Les Spheres !";
                FindObjectOfType<playerCollision>().objectifTag = "circle";
                break;

                //Facile
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

            //difficile
            //Spheres
            case 3:
                obj = "Les Spheres Jaune !";
                FindObjectOfType<playerCollision>().objectifTag = "circleY";
                break;
            case 4:
                obj = "Les Spheres Bleu !";
                FindObjectOfType<playerCollision>().objectifTag = "circleB";
                break;
            case 5:
                obj = "Les Spheres Violet !";
                FindObjectOfType<playerCollision>().objectifTag = "circleP";
                break;

            //Triangles
            case 6:
                obj = "Les Triangles Jaune !";
                FindObjectOfType<playerCollision>().objectifTag = "triangleY";
                break;
            case 7:
                obj = "Les Triangles Bleu !";
                FindObjectOfType<playerCollision>().objectifTag = "triangleB";
                break;
            case 8:
                obj = "Les Triangles Violet !";
                FindObjectOfType<playerCollision>().objectifTag = "triangleP";
                break;

            //Cubes
            case 9:
                obj = "Les Cubes Jaune !";
                FindObjectOfType<playerCollision>().objectifTag = "cubeY";
                break;
            case 10:
                obj = "Les Cubes Bleu !";
                FindObjectOfType<playerCollision>().objectifTag = "cubeB";
                break;
            case 11:
                obj = "Les Cubes Violet !";
                FindObjectOfType<playerCollision>().objectifTag = "cubeP";
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
