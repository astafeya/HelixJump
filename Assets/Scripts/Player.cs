using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Platform CurrentPlatform;
    public Platform PreviousPlatform;
    public Game Game;
    public SoundControl SoundControl;
    public Material Material;
    public ParticleSystem Drops;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    private void Awake()
    {
        Material.SetFloat("_Edge", 0);
    }

    private void Update()
    {
        if (PreviousPlatform == null) return;
        DestroyPreviousPlatform();
        PreviousPlatform = null;
    }

    public void Bounce()
    {
        if (!(Game.CurrentState == Game.State.Playing)) return;
        Drops.Play();
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        SoundControl.PlayBallBounce();
    }

    public void Die()
    {
        Rigidbody.velocity = Vector3.zero;
        StartCoroutine(Dissolve());
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

    private IEnumerator Dissolve()
    {
        float counter = 0;
        while (Material.GetFloat("_Edge") < 1)
        {
            counter+= dissolveRate;
            Material.SetFloat("_Edge", counter);
            yield return new WaitForSeconds(refreshRate);
        }
    }

    private void DestroyPreviousPlatform()
    {
        PreviousPlatform.PlaySectorDestroy();
    }

}
