using UnityEngine;

public class MetalReaction : MonoBehaviour, IHaveProjectileReaction
{
    public Transform[] metalImpactPrefabs;
    public void React(Collision collision)
    {
        Debug.Log($"{gameObject.name} reacted as Metal.");
        ContactPoint contact = collision.contacts[0];
        Instantiate(metalImpactPrefabs[Random.Range
                (0, metalImpactPrefabs.Length)], contact.point,
                Quaternion.LookRotation(contact.normal));
    }
}
