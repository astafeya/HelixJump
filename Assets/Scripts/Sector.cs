using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsBad = false;
    public bool IsFinish = false;
    public Material GoodMaterial;
    public Material BadMaterial;
    public Material FinishMaterial;
    private Material _currentMaterial;
    public ParticleSystem SectorDestroy;
    public ParticleSystem Confetti;

    public void UpdateMaterial()
    {
        if (IsFinish)
        {
            GetComponent<Renderer>().material = FinishMaterial;
            return;
        }
        GetComponent<Renderer>().material = IsBad ? BadMaterial : GoodMaterial;
        _currentMaterial = GetComponent<Renderer>().material;
        SectorDestroy.GetComponent<Renderer>().material = IsBad ? BadMaterial : GoodMaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        Vector3 normale = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normale, Vector3.up);
        if (dot < 0.5) return;
        if (!IsBad && !IsFinish)
            player.Bounce();
        else if (IsFinish)
        {
            PlayConfetti();
            player.Win();
        }
        else player.Die();
    }

    public void PlaySectorDestroy()
    {
        SectorDestroy.Play();
        _currentMaterial.SetFloat("_Alpha", 0);
    }

    public void PlayConfetti()
    {
        Confetti.Play();
    }

}
