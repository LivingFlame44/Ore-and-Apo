using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    public bool deletePlayerPrefs;
    // Start is called before the first frame update
    private void Awake()
    {
        if (deletePlayerPrefs == true)
        {
            DontDestroyOnLoad(this.gameObject);
            PlayerPrefs.DeleteAll();
        }
    }

    
}
