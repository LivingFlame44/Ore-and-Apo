using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject settingsPanel;
    public GameObject menuPanel;
    public GameObject levelSelectPanel;

    public static int currentMenuScene = 0;
    private void Awake()
    {
        if (currentMenuScene == 0)
        {
            ShowMainMenu();
        }
        else if (currentMenuScene == 1)
        {
            LevelMenu();
        }
        else if (currentMenuScene == 2)
        {
            Settings();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Settings()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
    public void LevelMenu()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }
    public void ShowMainMenu()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
    }

    public void ChangeScene_MainMenu()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        UIManager.currentMenuScene = 0;
        SceneManager.LoadScene("MainMenu");
    }
    public void ChangeScene_Level1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void ChangeScene_Level2()
    {
        SceneManager.LoadScene("Level 2");
    }
    
    public void Restart()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
  
    public void Quitgame()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        Application.Quit();

        //you can't quit the game inside the inspector
        Debug.Log("LABAS!!!");
    }

    public void SettingsBack()
    {
        AudioManager.Instance.PlaySFX("Ore_Bite2");
        if(SceneManager.loadedSceneCount > 1)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
        }
        else
        {
            ChangeScene_MainMenu();
        }

    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
