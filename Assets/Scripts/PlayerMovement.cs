using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5.0f;  // Constant forward speed
    public float horizontalMultiplier = 2.0f;
    //bool alive = true;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");

        // Si pasa cualquier cosa y se sale de la pista
        if (transform.position.y < -5)
        {
            Die();
        }

        // Calculate the forward movement (Z-axis)
        Vector3 forwardMove = transform.forward * forwardSpeed;

        // Calculate the lateral movement (X-axis) based on player input
        Vector3 horizontalMove = transform.right * horizontalMultiplier * Input.GetAxis("Horizontal");

        // Combine forward and lateral movement
        Vector3 moveDirection = forwardMove + horizontalMove;

        // Apply the movement using the CharacterController
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Die()
    {
        //alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
