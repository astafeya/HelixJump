using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text Text;
    public Score Score;
    public void Start()
    {
        Text.text = Score.OldScore.ToString();
    }
}
