public class WeaponData
{
    private int damage;
    private float attackCooldown;

    public WeaponData(int damage, float attackCooldown)
    {
        this.damage = damage;
        this.attackCooldown = attackCooldown;
    }

    public int GetDamage()
    {
        return damage;
    }

    public float GetAttackCooldown()
    {
        return attackCooldown;
    }
}