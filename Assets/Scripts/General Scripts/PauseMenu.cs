using UnityEngine.SceneManagement;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;

    public GameObject pauseCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true; 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void CloseGame()
    {
        Application.Quit();
    }



}
