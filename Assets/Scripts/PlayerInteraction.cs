using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Config")]
    public float distancia = 3f;
    public LayerMask interactuableMask;
    public KeyCode tecla = KeyCode.E;

    Camera cam;

    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        // Rayo desde la cámara hacia adelante para abrir Porton
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distancia, Color.green);

        if (Physics.Raycast(ray, out RaycastHit hit, distancia, interactuableMask))
        {
            if (Input.GetKeyDown(tecla))
            {
                var interactuable = hit.collider.GetComponentInParent<IInteractuable>();
                interactuable?.Interactuar();
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * distancia, Color.green);
    }

    
}
