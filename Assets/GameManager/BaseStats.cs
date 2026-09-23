public class BaseStats
{
    private int health;
    private float speed;

    public BaseStats(int health, float speed)
    {
        this.health = health;
        this.speed = speed;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}