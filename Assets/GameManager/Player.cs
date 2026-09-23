using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private BaseStats stats;
    private WeaponData weapon;

    [SerializeField] private float attackRange = 4f;

    private float nextAttackTime;
    private Vector2 moveInput;

    private void Awake()
    {
        stats = new BaseStats(100, 5f);

        WeaponData startingWeapon = new WeaponData(25, 1.5f);
        SetWeapon(startingWeapon);

        Debug.Log("Player creado con " + stats.GetHealth() + " de vida.");
    }

    private void Update()
    {
        // Movimiento
        transform.Translate(
            moveInput * stats.GetSpeed() * Time.deltaTime
        );

        // Ataque automático
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + weapon.GetAttackCooldown();
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void Attack()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemies)
        {
            float distance = Vector2.Distance(
                transform.position,
                enemyObject.transform.position
            );

            if (distance <= attackRange)
            {
                Enemy enemy = enemyObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(weapon.GetDamage());

                    Debug.Log(
                        "Player atacó automáticamente. Distancia: " + distance
                    );
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);

        Debug.Log("Player recibió " + damage + " de daño.");
        Debug.Log("Vida del Player: " + stats.GetHealth());

        if (stats.IsDead())
        {
            Debug.Log("Player está muerto.");
        }
    }

    public void SetWeapon(WeaponData newWeapon)
    {
        weapon = newWeapon;
        Debug.Log("Arma equipada.");
    }

    public BaseStats GetStats()
    {
        return stats;
    }

    public WeaponData GetWeapon()
    {
        return weapon;
    }
}