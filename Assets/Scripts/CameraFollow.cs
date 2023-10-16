using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
/// <summary>
/// Actualiza la posición de la cámara para seguir al jugador en el eje Z.
/// </summary>
/// <remarks>
/// La posición de la cámara se actualiza cada frame acorde con la posición del jugador.
/// No queremos que la cámara se mueva en el eje x por eso se deja a 0, solo nos interesa que siga al jugador en el eje Z (el eje y no se modifica).
/// </remarks>
{
    public Transform player;
    Vector3 offset;
    Vector3 targetPos;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        targetPos = transform.position = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
