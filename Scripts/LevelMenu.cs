using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public static int currLevel;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            (buttons[i]).transform.GetChild(0).gameObject.SetActive(false);
            
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            buttons[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            (buttons[i].transform.GetChild(0).gameObject).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text
                 = "x" + PlayerPrefs.GetInt("star" + (i+1).ToString(), 0);
        }
    }
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        currLevel = levelId;
        SceneManager.LoadScene(levelName);
        
    }
}
