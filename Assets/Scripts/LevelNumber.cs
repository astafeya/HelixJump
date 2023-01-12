using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    public Text CurrentLevel;
    public Text NextLevel;
    public Game Game;

    void Start()
    {
        CurrentLevel.text = (Game.LevelIndex + 1).ToString();
        NextLevel.text = (Game.LevelIndex + 2).ToString();
    }
}
