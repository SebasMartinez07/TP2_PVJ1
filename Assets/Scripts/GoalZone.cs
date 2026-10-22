using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        {
            Debug.Log("¡Victoria, has escapado!");
            GameManager.Instance.CambiarEstado(EstadoJuego.Victoria);
        }
    }
}
