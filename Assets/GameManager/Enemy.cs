using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BaseStats stats;

    private void Awake()
    {
        stats = new BaseStats(50, 2f);

        Debug.Log("Enemy creado con " + stats.GetHealth() + " de vida.");
    }

    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);

        Debug.Log("Enemy recibió " + damage + " de daño.");
        Debug.Log("Vida del Enemy: " + stats.GetHealth());

        if (stats.IsDead())
        {
            Destroy(gameObject);
        }
    }

    public BaseStats GetStats()
    {
        return stats;
    }

    private void OnDestroy()
    {
        Debug.Log("Enemy destruido correctamente.");
    }
}