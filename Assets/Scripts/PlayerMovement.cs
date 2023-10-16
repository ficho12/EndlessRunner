using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5.0f;  // Constant forward speed
    public float horizontalMultiplier = 2.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public UI UI;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si pasa cualquier cosa y se sale de la pista (No debería pasar)
        if (transform.position.y < -5)
        {
            Die();
        }

        // Calculate el movimiento
        Vector3 forwardMove = transform.forward * forwardSpeed;
        Vector3 horizontalMove = transform.right * horizontalMultiplier * Input.GetAxis("Horizontal");

        // Combinar los movimientos
        Vector3 moveDirection = forwardMove + horizontalMove;

        // Aplicar el movimiento usando el CharacterController
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Die()
    {
        UI.ChangeUItoEndLevel();
    }
}

