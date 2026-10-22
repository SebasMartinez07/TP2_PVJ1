using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronKamikaze : MonoBehaviour
{
    [Header("Movimiento")]
    public float velRecto = 4f;
    public float velPersecucion = 7f;
    public Transform puntoFin;
    public float distParaDestruirse = 1.5f;

    [Header("Ataque")]
    public float radioDeteccion = 8f;
    public int daño = 20;
    public float radioImpacto = 1.2f;

    private Transform player;
    private bool persiguiendo = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;
        float distPlayer = Vector3.Distance(transform.position, player.position);

        // Si te ve, cambia a modo persecución
        if (distPlayer < radioDeteccion) persiguiendo = true;

        if (persiguiendo)
        {
            // prrsigue al player
            Vector3 dir = (player.position - transform.position).normalized;
            transform.position += dir * velPersecucion * Time.deltaTime;
            transform.LookAt(player);

            if (distPlayer < radioImpacto)
            {
                var vida = player.GetComponent<HealthSystem>();
                if(vida != null) vida.TakeDamage(daño);
                Destroy(gameObject); // explota
            }
        }
        else
        {
            // va recto hacia el Punto_Fin
            transform.Translate(Vector3.forward * velRecto * Time.deltaTime);
            
            if (puntoFin != null && Vector3.Distance(transform.position, puntoFin.position) < distParaDestruirse)
            {
                Destroy(gameObject); // llegó al final y se borra solo
            }
        }
    }
}