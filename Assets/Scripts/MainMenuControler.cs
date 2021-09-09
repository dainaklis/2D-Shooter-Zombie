using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{

    [Header ("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;


    // ----------------------------------------------------------------------------------
    public void Playgame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlaygameDefense()
    {
        SceneManager.LoadScene("LevelDefense");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteAll();
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
