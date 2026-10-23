# TP N°2 - Metal Gear Solid: Ghost Infiltration

### CubeGame Studios - Programación de Videojuegos 1

**Desarrollador:** Sebastián Luciano Martínez <br>
**LU:** TUV000621 <br>
**Repositorio:** https://github.com/SebasMartinez07/TP2_PVJ1 <br>
**Motor:** Unity 3D <br>
**Versión:** 2022.3.62f3 <br>

\---

### Descripción del Juego

Prototipo de infiltración sigilosa en tercera persona. El jugador debe escapar de una base enemiga construida con **Unity Terrain Tool**.

El nivel cuenta con 2 enemigos con patrullaje por **NavMesh**, un portón con interacción por Raycast, coleccionables con sistema de puntaje, trampas láser parpadeantes, una zona de barro que ralentiza el movimiento y un sistema de drones kamikaze que patrullan hasta un punto final.

El objetivo es recolectar la información (puntos "USBColeccion") y llegar a la `GoalZone` para activar el estado de **Victoria**. Si la vida llega a 0, se activa **Derrota**. Todo gestionado por un `GameManager`.

\---

### Guía de Controles

|Acción|Tecla / Input|
|-|-|
|**Movimiento**|`W, A, S, D`|
|**Mirar alrededor**|`Mouse`|
|**Salto**|`Barra Espaciadora` (con chequeo de suelo por `Raycast + LayerMask`)|
|**Interacción (Puertas)**|`Tecla E` (Raycast desde la cámara con Layer `Interactuable`)|
|**Pausa / Reanudar**|`ESC` o `P` (cambia `Time.timeScale` a 0)|

\---

### Detalle de Puntos Opcionales Elegidos

Se eligieron **3 opcionales: C, D y E**.

#### Opcional C - Trampa Láser con Daño Continuo

**Script:** `Assets/Scripts/LaserDamage.cs`

Implementado como cubo con `Box Collider Is Trigger`. No mata instantáneo, hace daño cada 1 segundo.

* Variables: `daño = 10`, `dañoCadaSegundos = 1f`, `ultimoDaño`, `timer`, `Renderer rend`, `Collider col`.
* Lógica: En `Start()` pone `col.isTrigger = true`. En `OnTriggerStay(Collider other)` verifica `CompareTag("Player")` y `Time.time < ultimoDaño + dañoCadaSegundos`. Si pasa, busca `HealthSystem` y llama a `TakeDamage(daño)` + `Debug.Log("¡Daño de Laser!")`.

#### Opcional D - Zona de Barro (Ralentización)

**Implementación:** `Physics Material + Cubo como suelo` (sin script)

En lugar de modificar por código la velocidad, se resolvió con físicas de Unity.

* Se creó un `Physic Material` llamado `PM\_Barro` con `Dynamic Friction = 10` y `Static Friction = 10` y `Friction Combine = Maximum`.
* Se creó un cubo estirado como suelo al final del pasillo.
* Al entrar, el `Rigidbody` del Player pierde tracción y se ralentiza por fricción. Al salir, vuelve a velocidad normal. No requiere modificar `PlayerMovement`.

#### Opcional E - Spawner de Drones Kamikaze

**Scripts:** `Assets/Scripts/SpawnerDrones.cs` + `Assets/Scripts/DronKamikaze.cs`

* **Jerarquía:** `SpawnerDrones` (Vacío) contiene a `Punto\_Spawn` (origen) y `Punto\_Fin` (destino final). El prefab del Dron está en `Project/Prefabs`.
* **SpawnerDrones.cs:** Spawnea cada `intervalo = 8f y 12f`. Respeta `GameManager.Instance.estadoActual != Jugando` para no spawnear en Pausa/Victoria/Derrota. Al instanciar: `Instantiate(dronPrefab, puntoSpawn.position, etc.)` y le asigna dinámicamente `nuevo.GetComponent<DronKamikaze>().puntoFin = puntoFin;`
* **DronKamikaze.cs:** Movimiento con `Translate`. Variables: `velRecto = 3f`, `velPersecucion = 7f`, `puntoFin`, `distParaDestruirse = 1.5f`, `radioDeteccion = 8f`, `radioImpacto = 1.2f`, `daño = 20`.
Lógica: En `Update()` calcula `distPlayer`. Si `distPlayer < radioDeteccion`, `persiguiendo = true`, hace `LookAt(player)` y se mueve hacia él. Si `distPlayer < radioImpacto`, busca `HealthSystem` del player, hace `TakeDamage(daño)` y `Destroy(gameObject)`. Si no persigue, va recto con `Translate(Vector3.forward)` hacia `puntoFin` y al llegar a `distParaDestruirse` se autodestruye.
* **Visual:** `Rango\_Daño` es un Cylinder hijo con material transparente rojo `RangoMaterial` escalado a `radioDeteccion \* 2`, visible en ventana Game para que el jugador sepa la zona de peligro.

\---

### Capturas

### Mapa Completo

[Mapa Completo](Screenshots/MapaCompleto.png)

### 1ra Parte del Mapa (2 Enemigos patrullan la zona)

[1ra Parte del Mapa](Screenshots/1ra_ParteMapa.png)

### 2da Parte del Mapa (Spawner de Drones, Rayos Laseres y Suelo con Physics Material)

[2da Parte del Mapa](Screenshots/2da_ParteMapa.png)

### Zona de Victoria

[Zona de Victoria](Screenshots/GoalZone.png)

\---
