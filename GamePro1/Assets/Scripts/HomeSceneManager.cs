using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    public void GoToPlayGround()
    {
        SceneManager.LoadScene("Playground");
    }

    public void CountinuePlay()
    {
        if (PlayerPrefs.HasKey("PrevScene"))
        {
            string PrevSceneName = PlayerPrefs.GetString("PrevScene");
            SceneManager.LoadScene(PrevSceneName);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
