using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform jumpRaycast;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpDelay = 1.0f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;
    private bool isGrounded;
    private PlayerAnimationController playerAnimationController;
    private float lastJumpTime = 0f;
    private bool death = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
        GameManager.instance.InitPlayerController(this);
    }

    void Update()
    {
        if (death)
            return;
        
        IsGrounded();
        Move();
        Jump();
        MoveDirection();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
        rb.velocity = moveDirection.normalized * moveSpeed;
    }

    private void MoveDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        // Плавное изменение угла поворота
        if (moveDirection.x != 0)
        {
            float targetRotation = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, targetRotation, 0),
                rotationSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump") && Time.time - lastJumpTime > jumpDelay)
        {
            rb.AddForce(Vector3.up * jumpForce);
            playerAnimationController.Jump();
            lastJumpTime = Time.time;
        }
    }

    private void IsGrounded()
    {
        isGrounded = Physics.Raycast(jumpRaycast.position, Vector3.down, 0.5f, groundLayer);
        Debug.DrawRay(jumpRaycast.position, Vector3.down*0.5f, Color.red);
    }

    public void Death()
    {
        death = true;
        playerAnimationController.AnimateDeath();
    }
}