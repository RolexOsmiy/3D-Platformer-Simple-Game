using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
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
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
    
    public void Jump()
    {
        if (death)
            return;
        animator.Play("Jump");
    }

    public void AnimateDeath()
    {
        death = true;
        animator.Play("Death");
    }
}