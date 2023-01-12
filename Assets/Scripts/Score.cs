using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private const string SCORE = "Score";
    private const string BEST_SCORE = "BestScore";
    public Text ScoreText;
    public Text BestScoreText;

    public int PlayerScore
    {
        get => PlayerPrefs.GetInt(SCORE, 0);
        private set
        {
            PlayerPrefs.SetInt(SCORE, value);
            PlayerPrefs.Save();
        }
    }

    public int BestScore
    {
        get => PlayerPrefs.GetInt(BEST_SCORE, 0);
        private set
        {
            PlayerPrefs.SetInt(BEST_SCORE, value);
            PlayerPrefs.Save();
        }
    }

    public int OldScore
    {
        get;
        private set;
    }

    public void Increase(int score)
    {
        PlayerScore += score;
        OldScore = PlayerScore;
        UpdateBestScore();
    }

    public void Reset()
    {
        UpdateBestScore();
        PlayerScore = 0;
    }

    private void UpdateBestScore()
    {
        if (PlayerScore > BestScore)
            BestScore = PlayerScore;
    }

    public void Start()
    {
        ScoreText.text = PlayerScore.ToString();
        BestScoreText.text = "Best score: " + BestScore.ToString();
    }
    
    public void Update()
    {
        ScoreText.text = PlayerScore.ToString();
    }
}
