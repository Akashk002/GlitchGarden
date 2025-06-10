using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManager : GenericMonoSingleton<UIManager>
{
    [SerializeField] private TMP_Text starCountText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Slider waveSlider;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject GamePausePanel;
    [SerializeField] private GameObject GameCompletePanel;

    // Start is called before the first frame update
    public void OpenGameOverPanel()
    {
        AudioService.Instance.Play(SoundType.GameOver);
        PlayPauseGame();
        GameOverPanel.SetActive(true);
    }

    public void OpenGameCompletePanel()
    {
        AudioService.Instance.Play(SoundType.GameComplete);
        PlayPauseGame();
        GameCompletePanel.SetActive(true);
    }

    public void OpenGamePausePanel()
    {
        AudioService.Instance.Play(SoundType.GamePause);
        PlayPauseGame();
        GamePausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        AudioService.Instance.PlayClickSound();
        PlayPauseGame();
        GamePausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        AudioService.Instance.PlayClickSound();
        PlayPauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        AudioService.Instance.PlayClickSound();
        PlayPauseGame();
        SceneManager.LoadScene("Menu");
    }

    public void UpdateStarCount(int val)
    {
        starCountText.SetText(val.ToString());
    }

    public void UpdateLevelNumber(int level)
    {
        levelText.SetText("Level - " + level);
    }

    public void UpdateLevelSlider(int value)
    {
        waveSlider.value = value;
    }

    private void PlayPauseGame()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

}
