using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowards : MonoBehaviour
{
    public float moveSpeed = 5;

    /*
     * Script simple para mover el enemigo con la velocidad relativa a la del jugador (moveSpeed) en el eje Z.
     * El movimiento sinusoidal se ejecutará en el script Enemy.cs
     */
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos.z -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
