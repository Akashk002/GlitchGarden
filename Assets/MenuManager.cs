using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        AudioService.Instance.PlayClickSound();
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        AudioService.Instance.PlayClickSound();
        Application.Quit();
    }
}
