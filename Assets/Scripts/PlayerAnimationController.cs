using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Rigidbody rb;
    private bool death = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        if (death)
            return;
        
        // Передаем текущую скорость в параметр анимации speed
        animator.SetFloat("Speed", Input.GetAxis("Horizontal") != 0 ? rb.velocity.magnitude : 0f);
        //animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
    
    public void Jump()
    {
        if (death)
            return;
        animator.SetTrigger("Jump");
    }

    public void AnimateDeath()
    {
        death = true;
        animator.Play("Death");
    }
}