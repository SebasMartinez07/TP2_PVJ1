using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [Header ("Puntos")]
    public int puntos = 10;
    public string tagPlayer = "Player";

    [Header("Efecto")]
    public float velocidadRotacion = 80f;

    void Update()
    {
        transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            ScoreManager.Instance.SumarPuntos(puntos);
            Destroy(gameObject);
        }
    }
}
