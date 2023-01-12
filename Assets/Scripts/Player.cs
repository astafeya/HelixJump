using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Platform CurrentPlatform;
    public Game Game;
    public SoundControl SoundControl;

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        SoundControl.PlayBallBounce();
    }

    public void Die()
    {
        Rigidbody.velocity = Vector3.zero;
        Game.OnPlayerDied();
        CurrentPlatform = null;
    }

    public void Win()
    {
        Rigidbody.velocity = Vector3.zero;
        Game.OnPlayerWin();
        CurrentPlatform = null;
    }

    public void AddScore()
    {
        Game.AddScore();
        SoundControl.PlayPlatformBreak();
    }
    
}
