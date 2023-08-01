using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private MovementParameterSO movementSO;
	private Rigidbody2D rb;
	private Vector2 moveInput;
	private bool isJumping;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		// Read move input from New Input System
		moveInput = InputManager.Instance.GetMoveInput();

		// Check for jump input
		isJumping = movementSO.canJump && InputManager.Instance.GetJumpInput();
	}

	private void FixedUpdate()
	{
		MoveCharacter();
		if (isJumping)
		{
			Jump();
			isJumping = false;
		}
	}

	private void MoveCharacter()
	{
		// Apply horizontal movement to the character
		Vector2 moveVelocity = new Vector2(moveInput.x * movementSO.moveSpeed, rb.velocity.y);
		rb.velocity = moveVelocity;
	}

	private void Jump()
	{
		if (!movementSO.canJump) return;

		// Apply jump force to the character
		rb.AddForce(new Vector2(0f, movementSO.jumpForce), ForceMode2D.Impulse);
	}
}
