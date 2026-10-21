using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float daño = 15f;
    public float rango = 1.5f;
    public float cooldown = 1f;

    Transform player;
    HealthSystem playerHealth;
    float ultimoGolpe;

    void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        player = p.transform;
        playerHealth = p.GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (playerHealth.IsDead) return;

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= rango && Time.time > ultimoGolpe + cooldown)
        {
            ultimoGolpe = Time.time;
            playerHealth.TakeDamage(daño);
        }
    }
}