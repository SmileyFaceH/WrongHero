using UnityEngine.SceneManagement;
using UnityEngine;

public class CloseGame : MonoBehaviour
{

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void CloseGameOnClick()
    {
        Application.Quit();
    }
}
