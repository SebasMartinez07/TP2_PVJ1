using UnityEngine;
using UnityEngine.SceneManagement;

public enum EstadoJuego { Inicio, Jugando, Pausa, Victoria, Derrota }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Estado Actual")]
    public EstadoJuego estadoActual = EstadoJuego.Inicio;

    [Header("UI - Arrastrá tus paneles acá")]
    public GameObject panelInicio;
    public GameObject panelHUD;
    public GameObject panelPausa;
    public GameObject panelVictoria;
    public GameObject panelDerrota;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Arranca en Inicio
        CambiarEstado(EstadoJuego.Inicio);
    }

    void Update()
    {
        // Pausa con ESC solo si estás jugando
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estadoActual == EstadoJuego.Jugando)
                CambiarEstado(EstadoJuego.Pausa);
            else if (estadoActual == EstadoJuego.Pausa)
                ReanudarJuego();
        }
    }

    public void CambiarEstado(EstadoJuego nuevoEstado)
    {
        estadoActual = nuevoEstado;

        // Apagamos todos los paneles primero
        if(panelInicio) panelInicio.SetActive(false);
        if(panelHUD) panelHUD.SetActive(false);
        if(panelPausa) panelPausa.SetActive(false);
        if(panelVictoria) panelVictoria.SetActive(false);
        if(panelDerrota) panelDerrota.SetActive(false);

        switch (nuevoEstado)
        {
            case EstadoJuego.Inicio:
                Time.timeScale = 0f;
                if(panelInicio) panelInicio.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;

            case EstadoJuego.Jugando:
                Time.timeScale = 1f;
                if(panelHUD) panelHUD.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;

            case EstadoJuego.Pausa:
                Time.timeScale = 0f;
                if(panelPausa) panelPausa.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;

            case EstadoJuego.Victoria:
                Time.timeScale = 0f;
                if(panelVictoria) panelVictoria.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Debug.Log("ESTADO: VICTORIA");
                break;

            case EstadoJuego.Derrota:
                Time.timeScale = 0f;
                if(panelDerrota) panelDerrota.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Debug.Log("ESTADO: DERROTA");
                break;
        }
    }

    // --- Métodos para los botones de la UI ---

    public void IniciarJuego()
    {
        CambiarEstado(EstadoJuego.Jugando);
    }

    public void ReanudarJuego()
    {
        CambiarEstado(EstadoJuego.Jugando);
    }

    public void PausarJuego()
    {
        CambiarEstado(EstadoJuego.Pausa);
    }

    public void Victoria()
    {
        CambiarEstado(EstadoJuego.Victoria);
    }

    public void Derrota()
    {
        CambiarEstado(EstadoJuego.Derrota);
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}