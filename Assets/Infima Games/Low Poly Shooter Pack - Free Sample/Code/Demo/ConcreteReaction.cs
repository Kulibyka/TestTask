using UnityEngine;

public class ConcreteReaction : MonoBehaviour, IHaveProjectileReaction
{
    public Transform[] concreteImpactPrefabs;
    public void React(Collision collision)
    {
        Debug.Log($"{gameObject.name} reacted as Concrete.");
        ContactPoint contact = collision.contacts[0];
        Instantiate(concreteImpactPrefabs[Random.Range
                (0, concreteImpactPrefabs.Length)], contact.point,
                Quaternion.LookRotation(contact.normal));
    }
}
