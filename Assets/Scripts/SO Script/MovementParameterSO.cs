using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MovementParameter", menuName = "ScriptableObject/MovementParameter", order = 1)]
public class MovementParameterSO : ScriptableObject
{
    [Header("Movement Settings")]
	public float moveSpeed = 5f; // Character movement speed

	[Header("Jump Settings")]
	public bool canJump = true; // Can the character jump?
	public float jumpForce = 10f; // Jump force applied to the character
}
