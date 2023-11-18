using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public GameObject player;
    public bool isGameOver = false;
    public GameObject[] masters;
    public GameObject[] mastersMenu;
    public GameObject ClearPanel;
    public GameObject GameOverScreen;
    public void AddScore(int scorePoint)
    {
        masters[score].SetActive(true);
        mastersMenu[score].SetActive(true);
        score += scorePoint;
       
    }
    void Start()
    {
      
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        Debug.Log("GAME OVER!");
    }

    public void StageClear()
    {
        ClearPanel.SetActive(true);
        if (score > PlayerPrefs.GetInt("star" + LevelMenu.currLevel.ToString()))
        {
            PlayerPrefs.SetInt("star" + LevelMenu.currLevel.ToString(), score);
            PlayerPrefs.Save();
        }
        Time.timeScale = 0;
    }

}