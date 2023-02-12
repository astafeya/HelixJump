using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsBad = false;
    public bool IsFinish = false;
    public Material GoodMaterial;
    public Material BadMaterial;
    public Material FinishMaterial;
    private Material _currentMaterial;
    public ParticleSystem System;

    public void UpdateMaterial()
    {
        if (IsFinish)
        {
            GetComponent<Renderer>().material = FinishMaterial;
            return;
        }
        GetComponent<Renderer>().material = IsBad ? BadMaterial : GoodMaterial;
        _currentMaterial = GetComponent<Renderer>().material;
        System.GetComponent<Renderer>().material = IsBad ? BadMaterial : GoodMaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        Vector3 normale = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normale, Vector3.up);
        if (dot < 0.5) return;
        if (!IsBad && !IsFinish)
            player.Bounce();
        else if (IsFinish) player.Win();
        else player.Die();
    }

    public void PlaySystem()
    {
        System.Play();
        _currentMaterial.SetFloat("_Alpha", 0);
    }

}
