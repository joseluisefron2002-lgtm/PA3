using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 5f;

    private Vector2 moveInput;

    public float gravity = -9.8f;
    private float verticalVelocity;

    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (controller.isGrounded && verticalVelocity<0 )
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        Vector3 velocity = move * speed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

   






}
