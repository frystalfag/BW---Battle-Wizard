using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.Text;

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
    private CharacterContext character;
    private Animator animator;
    private HealthBar PlayerHealth;
    private Vector3 velocity;
    private bool isGrounded;
    private float currentSpeed;
    private float speedBlend;
    
    private readonly int DieAnimParam = Animator.StringToHash("Die");

    void Start()
    {
        controller = GetComponent<CharacterController>();
        character = GetComponent<CharacterContext>();
        PlayerHealth = GetComponent<HealthBar>();
        animator = GetComponentInChildren<Animator>();
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
        bool isMoving = move.magnitude > 0.1f;
        
        float curSpeed = isMoving ? (isRunning ? runSpeed : walkSpeed) : 0f;
        speedBlend = Mathf.MoveTowards(speedBlend, curSpeed,    0.5f * Time.deltaTime);
        controller.Move(move * curSpeed * Time.deltaTime);
        
        character.ChangeState(new MovementState(animator, speedBlend, character) );
        

        // character.ChangeState(new WalkForwardState(character));
        // animator.SetBool("Run", isMoving && isRunning);
    }

    private void HandleJumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //animator.SetTrigger("Jump");
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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}