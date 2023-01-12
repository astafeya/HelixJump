using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CurrentState { get; private set; }
    private const string LEVEL_INDEX_KEY = "LevelIndex";

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LEVEL_INDEX_KEY, 0);
        private set
        {
            PlayerPrefs.SetInt(LEVEL_INDEX_KEY, value);
            PlayerPrefs.Save();
        }
    }

    public Controls Controls;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public Score Score;

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        LosePanel.SetActive(true);
        Score.Reset();
        Debug.Log("Game Over!");
    }

    public void OnPlayerWin()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        WinPanel.SetActive(true);
        LevelIndex++;
        Debug.Log("You Won!");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()
    {
        Score.Increase(LevelIndex + 1);
    }
}
