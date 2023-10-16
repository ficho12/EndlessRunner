using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que controla el movimiento de un enemigo hacia el jugador en el eje Z.
/// </summary>
public class EnemyTowards : MonoBehaviour
{
    public float moveSpeed = 5;

    /// <summary>
    /// Script simple para mover el enemigo con la velocidad relativa a la del jugador (moveSpeed) en el eje Z.
    /// El movimiento sinusoidal se ejecutará en el script Enemy.cs
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos.z -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
