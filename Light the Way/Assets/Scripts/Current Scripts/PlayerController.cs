using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private float jumpHeight = 5;
    
    private Vector3 input;
    private Vector3 jumpInput;

    bool grounded = true;

    void Update()
    {
        GatherInput();
        Look();

    }

    void FixedUpdate()
    {
        Move();
    }

    //gathers info from keyboard/ controller input
    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0 ), ForceMode.Impulse);
        }

    }

    //based on player input, will change the forward direction of the character.
    void Look()
    {
        if (input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skewedInput = matrix.MultiplyPoint3x4(input);

            var relative = (transform.position + skewedInput) - transform.position;
            var playerRotation = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,playerRotation, turnSpeed * Time.deltaTime);
        }

    }

    //player movement
    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }


}
