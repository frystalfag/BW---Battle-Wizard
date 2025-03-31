using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float CurrentHealth;
    
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;

    private CharacterController controller;
    private Animator animator;
    private HealthBar PlayerHealth;
    private Vector3 velocity;
    private bool isGrounded;
    private float currentSpeed;
    
    private readonly int DieAnimParam = Animator.StringToHash("Die");

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        PlayerHealth = GetComponent<HealthBar>();
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        ApplyGravity();
        
        CurrentHealth = PlayerHealth.CurHealth;

        if (CurrentHealth <= 0)
        {
            StartCoroutine(Die());  
        }
    }

    private void HandleMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && isGrounded;
        currentSpeed = isRunning ? runSpeed : walkSpeed;
        
        controller.Move(move * currentSpeed * Time.deltaTime);
        
        bool isMoving = move.magnitude > 0.1f;
        animator.SetBool("Walk", isMoving);
        animator.SetBool("Run", isMoving && isRunning);
    }

    private void HandleJumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Die()
    {
        animator.SetBool(DieAnimParam, true);
        animator.SetBool(DieAnimParam, false);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}