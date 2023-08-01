using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; }

	private PlayerInputAction playerAction;

	private void Awake() {
		if (Instance != null && Instance != this) {
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

		playerAction = new PlayerInputAction();
		playerAction.Enable();
	}

	private void OnDisable() {
		playerAction.Disable();
	}

	public Vector2 GetMoveInput() {
		return playerAction.Player.Movement.ReadValue<Vector2>();
	}

	public bool GetJumpInput() {
		return playerAction.Player.Jump.triggered;
	}
}
