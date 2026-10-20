using System.Collections;
using UnityEngine;

public class PortonInteraccion : MonoBehaviour, IInteractuable
{
    public float angulo = 90f;
    public float velocidad = 2f;
    bool abierta = false;
    bool moviendose = false;
    Quaternion cerrada, abiertaRot;

    void Start()
    {
        cerrada = transform.rotation;
        abiertaRot = Quaternion.Euler(0, cerrada.eulerAngles.y + angulo, 0);
    }
    public void Interactuar()
    {
        if (moviendose) return;
        StartCoroutine(Rutina());
    }

    IEnumerator Rutina()
    {
        moviendose = true;
        Quaternion ini = abierta ? abiertaRot : cerrada;
        Quaternion fin = abierta ? cerrada : abiertaRot;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * velocidad;
            transform.rotation = Quaternion.Slerp(ini, fin, t);
            yield return null;
        }
        abierta = !abierta;
        moviendose = false;
        Debug.Log(abierta ? "Porton ABIERTO" : "Porton CERRADO");
    }
}