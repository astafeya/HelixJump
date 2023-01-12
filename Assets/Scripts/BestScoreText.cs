using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    public Text Text;
    public Score Score;
    public void Start()
    {
        Text.text = "Best score: " + Score.BestScore.ToString();
    }
}
