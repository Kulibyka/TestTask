using UnityEngine;

public class BloodReaction : MonoBehaviour, IHaveProjectileReaction
{
    public Transform[] bloodImpactPrefabs;
    public void React(Collision collision)
    {
        Debug.Log($"{gameObject.name} reacted as Concrete.");
        ContactPoint contact = collision.contacts[0];
        Instantiate(bloodImpactPrefabs[Random.Range
                (0, bloodImpactPrefabs.Length)], contact.point,
                Quaternion.LookRotation(contact.normal));
    }
}
