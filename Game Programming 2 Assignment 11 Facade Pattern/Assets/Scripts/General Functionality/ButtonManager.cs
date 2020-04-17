/*
* (Christopher Green)
* (ButtonManager.cs)
* (Assignment 9)
* (This script defines what buttons will do when they are clicked on.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public static ButtonManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadLevel(int levelBuildNum)
    {
        switch(levelBuildNum)
        {
            case 0:
                SceneManager.LoadScene(0);
                break;

            case 1:
                SceneManager.LoadScene(1);
                break;

            case 2:
                SceneManager.LoadScene(2);
                break;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
