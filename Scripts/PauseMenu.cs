using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool GameIsPaused = false;
   

    private void Awake()
    {
       
    }
    void Update(){
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        GameIsPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        UIManager.currentMenuScene = 0;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        GameIsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Settings()
    {
        UIManager.currentMenuScene = 2;
        SceneManager.LoadSceneAsync("MainMenu",LoadSceneMode.Additive);

    }
    public void Continue()
    {
        UIManager.currentMenuScene = 1;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
