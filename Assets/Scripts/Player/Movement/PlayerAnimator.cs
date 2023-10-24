using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void AnimateMovement(Vector3 movementDirection)
    {
        if (!animator) return;

        if (movementDirection.magnitude > 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("horizontal", movementDirection.x);
            animator.SetFloat("vertical", movementDirection.y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void FootstepSounds() 
    {
        AudioManager.Instance?.PlayFootstepSounds();
    }
}
