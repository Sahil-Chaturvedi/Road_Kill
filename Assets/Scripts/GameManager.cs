using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1f;
    public GameObject CompleteLevelUI;
    public void CompleteLevel()
    {
        CompleteLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("GAME OVER!");
            Invoke("Restart", restartDelay);
        }

    }

    void Restart()
    {
/*        Debug.Log("SceneManager.GetActiveScene().name" + SceneManager.GetActiveScene().name);
*/        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
