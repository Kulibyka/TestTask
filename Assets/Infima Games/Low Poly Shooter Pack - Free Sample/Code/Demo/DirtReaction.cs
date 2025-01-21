using UnityEngine;

public class DirtReaction : MonoBehaviour, IHaveProjectileReaction
{
    public Transform[] dirtImpactPrefabs;
    public void React(Collision collision)
    {
        Debug.Log($"{gameObject.name} reacted as Concrete.");
        ContactPoint contact = collision.contacts[0];
        Instantiate(dirtImpactPrefabs[Random.Range
                (0, dirtImpactPrefabs.Length)], contact.point,
                Quaternion.LookRotation(contact.normal));
    }
}
