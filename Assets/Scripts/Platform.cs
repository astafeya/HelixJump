using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public List<Sector> Sectors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.CurrentPlatform != null) player.AddScore();
            if (player.CurrentPlatform != this) player.PreviousPlatform = player.CurrentPlatform;
            player.CurrentPlatform = this;
        }
    }

    public void PlaySectorDestroy()
    {
        for (int i = 0; i < Sectors.Count; i++)
        {
            Sectors[i].PlaySectorDestroy();
        }
    }
}
