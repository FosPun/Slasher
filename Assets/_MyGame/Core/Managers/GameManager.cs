using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    
    
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    
    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }
}
