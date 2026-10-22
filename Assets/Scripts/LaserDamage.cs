using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    [Header("Daño")]
    public int daño = 25;
    public float dañoCadaSegundos = 1f; // no morir instantaneamnte
    private float ultimoDaño;
    private float timer;

    private Renderer rend;
    private Collider col;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        // Que sea trigger
        col.isTrigger = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (Time.time < ultimoDaño + dañoCadaSegundos) return;

        // Llamada al sistema de vida
        var vida = other.GetComponent<HealthSystem>();
        if (vida != null)
        {
            vida.TakeDamage(daño);
            ultimoDaño = Time.time;
            Debug.Log($"¡Daño de Laser!");
        }
    }
}