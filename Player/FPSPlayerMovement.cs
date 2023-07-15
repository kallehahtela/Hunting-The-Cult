using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AudioSource grassFootSteps;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        // Apply gravity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        // Move the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Play the audio source if the player is moving
        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)
        {
            if (!grassFootSteps.isPlaying)
            {
                grassFootSteps.Play();
            }
        }
        else
        {
            grassFootSteps.Stop();
        }

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        // Apply the velocity
        controller.Move(velocity * Time.deltaTime);
    }
}
