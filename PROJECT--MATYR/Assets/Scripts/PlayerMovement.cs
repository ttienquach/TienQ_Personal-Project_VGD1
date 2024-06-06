using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public bool grounded;
    private Vector3 startPosition;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        

        grounded = controller.isGrounded;

        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 input = transform.right * x + transform.forward * z;

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = jumpHeight;
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = input * speed + velocity;

        controller.Move(move * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.R))
        ResetPosition();
    }

    void ResetPosition()
    {
        Debug.Log("Reset position");
        transform.position = startPosition;
    }
}
