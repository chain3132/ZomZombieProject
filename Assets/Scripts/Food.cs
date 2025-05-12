using UnityEngine;

public class Food : MonoBehaviour
{
    public int attackPoint = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthV1>(out var health))
        {
            health.TakeDamage(attackPoint);
        }
        Destroy(gameObject);
    }
}
