using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDrones : MonoBehaviour
{
    public GameObject dronPrefab;
    public Transform puntoSpawn;
    public Transform puntoFin;
    public float intervalo = 4f;

    private float timer;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.estadoActual != EstadoJuego.Jugando)
            return;

        timer += Time.deltaTime;
        if (timer >= intervalo)
        {
            timer = 0f;
                GameObject nuevo = Instantiate(dronPrefab, puntoSpawn.position, puntoSpawn.rotation);
                nuevo.GetComponent<DronKamikaze>().puntoFin = puntoFin;
        }
    }
}
