using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    /*
     * La posici�n de la c�mara se actualiza cada frame acorde con la posici�n del jugador.
     * No queremos que la c�mara se mueva en el eje x por eso se deja a 0, solo nos interesa que siga al jugador en el eje Z (el eje y no se modifica).
     * targetPos = transform.position = player.position + offset;
     */
    void Update()
    {
        targetPos = transform.position = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
