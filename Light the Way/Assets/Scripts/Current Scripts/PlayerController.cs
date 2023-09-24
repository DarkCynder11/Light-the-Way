using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    
    [SerializeField] private float jumpHeight = 5;
    
    private Vector3 input;
    private Vector3 jumpInput;

    bool grounded = true;

    public enum PlayerMovementState
    {
        Normal,
        Swimming,
        Dead,
    }
    private PlayerMovementState currentState;

    private void Awake()
    {
        rb ??= GetComponent<Rigidbody>();
        currentState = PlayerMovementState.Normal;
    }

    void Update()
    {
        GatherMoveInput();
        Look();
        GatherJumpInput();

    }

    void FixedUpdate()
    {
        Move();
    }

    //gathers info from keyboard/controller input
    void GatherMoveInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    }

    private void GatherJumpInput()
    {
        switch (currentState)
        {
            case (PlayerMovementState.Normal):
                if (Input.GetButtonDown("Jump"))
                {
                    Debug.Log("jumping normal");
                    rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                }
                break;
            
            case (PlayerMovementState.Swimming):
                break;
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
        Debug.Log("moving");
    }

    public void ChangeMovementState(PlayerMovementState newState)
    {
        if (newState != currentState)
        {
        currentState = newState;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Water Pool") {
            Debug.Log("Fucking help me");
            ChangeMovementState(PlayerMovementState.Swimming);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Water Pool") {
            ChangeMovementState(PlayerMovementState.Normal);
        }
    }
}
