using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1f;
    public float actualScore = 0f;

    public GameObject levelCompleteUI;

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
        Debug.Log("Level COmplete !!");
    }
}
