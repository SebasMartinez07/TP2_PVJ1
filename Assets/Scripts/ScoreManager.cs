using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
public static ScoreManager Instance;
public int puntajeActual = 0;

public event Action<int> OnPuntajeCambiado;

void Awake() {Instance = this; }

public void SumarPuntos(int cantidad)
{
    puntajeActual += cantidad;
    OnPuntajeCambiado?.Invoke(puntajeActual);
    Debug.Log($"Puntaje actual: {puntajeActual}");
}
}
