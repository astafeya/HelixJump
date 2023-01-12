using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.CurrentPlatform != null) player.AddScore();
            player.CurrentPlatform = this;
        }
    }
}
