using UnityEngine;

public class ClothesAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (!playerMovement) { return; }

        Animate(playerMovement.playerMovementDirection);
    }

    public void Animate(Vector3 movementDirection)
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
}
