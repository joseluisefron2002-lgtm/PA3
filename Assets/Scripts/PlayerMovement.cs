using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    private Vector2 moveInput;

    public float gravity = -9.8f;
    private float verticalVelocity;

    public Transform modelTranform;
    public Transform cameraPivot;

    private Animator animator;

    private bool isRunning;
    private bool isMoving;
    public float walkSpeed = 3f;
    public float runSpeed = 6f;

    public float jumpForce = 5f;
    
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        float currentSpeed = (isRunning && isMoving) ? runSpeed : walkSpeed;


        if (controller.isGrounded && verticalVelocity<0 )
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 forward = cameraPivot.forward; 
        Vector3 right = cameraPivot.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 desireMoveDir = (forward * moveInput.y + right * moveInput.x);
        
        if(desireMoveDir.magnitude>0.1f)
        {
            Quaternion targetRotaion = Quaternion.LookRotation(desireMoveDir);
            modelTranform.rotation = Quaternion.Slerp(modelTranform.rotation, targetRotaion, 15f * Time.deltaTime);
        }
        
        

        Vector3 velocity = desireMoveDir * currentSpeed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);

        UpdateAnimator();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed && controller.isGrounded)
        {
            verticalVelocity = jumpForce;
            animator.SetTrigger("Jump");
        }
    }


    public void UpdateAnimator()
    {
        isMoving = moveInput.magnitude>0.1F;

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsRunning", isRunning && isMoving);
        animator.SetBool("Grounded", controller.isGrounded);
        animator.SetFloat("VerticalVelocity", verticalVelocity);
    }


}
