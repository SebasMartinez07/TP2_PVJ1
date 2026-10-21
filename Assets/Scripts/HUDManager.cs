using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header ("Referencias HUD")]
    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI textoPuntos;

    void Start()
    {
        ScoreManager.Instance.OnPuntajeCambiado += ActualizarPuntos;
        ActualizarPuntos(0);
    
    }

    public void ActualizarPuntos(int puntos)
    {
        textoPuntos.text = $"PUNTOS: {puntos}";
    }

    public void ActualizarVida(int vidaActual)
    {
        textoVida.text = $"VIDA: {vidaActual}";
    }
}
