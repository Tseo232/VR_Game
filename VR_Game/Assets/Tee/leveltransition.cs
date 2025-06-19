using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTransition : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;

    // This function shows the main menu and hides the controls
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    // This function shows the controls panel and hides the main menu
    public void ShowControls()
    {
        controlsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    // This function loads the next scene in the build settings
    public void LoadNextLevel()
    {

        SceneManager.LoadScene("Final");


    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
