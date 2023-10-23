using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerAnimator playerAnimator;

    private float horizontalAxis;
    private float verticalAxis;

    private Vector3 direction;

    private bool isPlayerMoving;

    public Vector3 playerMovementDirection { get; private set; }

    private void Update()
    {
        HandleMovementInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void HandleMovementInput()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontalAxis, verticalAxis);

        playerMovementDirection = direction;

        playerAnimator.AnimateMovement(direction);
    }

    private void MovePlayer()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    public bool IsPlayerMoving() { if (playerMovementDirection.magnitude > 0) return true; return false; }
}
