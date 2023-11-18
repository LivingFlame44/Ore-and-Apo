using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionScene : MonoBehaviour
{
    public static OptionScene instance;
    public GameObject goToOptions;
    public GameObject hideMenu;
    public void options()
    {
        SceneManager.LoadScene("MainMenu");
        goToOptions.SetActive(true);
        hideMenu.SetActive(false);
    }
}