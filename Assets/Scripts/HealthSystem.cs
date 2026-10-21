using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [Header("Configuracion Salud")]
    [SerializeField] private float maxHealth = 100f; 
    private float currentHealth; 
    public float CurrentHealth => currentHealth;

    [SerializeField] private bool isDead;
    public bool IsDead
    {
        get => isDead;
          
    }
    
    private void Awake() 
    { 
        currentHealth = maxHealth; 
        isDead = false; 
    }
    public void TakeDamage(float amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        //clamp permite normalizar un valor de acuerdo a los limites
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        
        /*
         * math.clamp(5, 1, 10) => 5 (esta dentro del rango)
         * math.clamp(-4, 0, 10) => 0 (es menor que el minimo, devuelve 0)
         * math.clamp(15, 0, 10) => 10 (es mayor que el maximo, devuelve 10)
         */

        Debug.Log($"Salud actual: {currentHealth}");
        if (currentHealth <= 0f)
        {
            Dead();
        }
    }
    private void Dead() 
    { 
        isDead = true; 
        Debug.Log("Player eliminado"); 
        // Notificación al GameManager si existiera 
        //GameManager.Instance.ChangeState(GameState.GameOver);
        //Destroy object
        //efectos
        //animaciones
    }

}