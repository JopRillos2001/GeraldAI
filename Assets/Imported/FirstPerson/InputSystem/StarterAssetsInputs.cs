using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interact;
		public bool pause;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		[Header("Can")]
		[SerializeField] private bool canMove = true;
		[SerializeField] private bool canLook = true;
		[SerializeField] private bool canJump = true;
		[SerializeField] private bool canSprint = true;
		[SerializeField] private bool canInteract = true;
		[SerializeField] private bool canPause = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			if (canMove) {
				MoveInput(value.Get<Vector2>());
			}
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook && canLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			if (canJump) {
				JumpInput(value.isPressed);
			}
		}

		public void OnSprint(InputValue value)
		{
			if (canSprint) {
				SprintInput(value.isPressed);
			}
		}

		public void OnInteract(InputValue value) {
			if (canInteract) {
				InteractInput(value.isPressed);
			}
		}

		public void OnPause(InputValue value) {
			if (canPause) {
				PauseInput(value.isPressed);
			}
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void InteractInput(bool newInteractState) {
			interact = newInteractState;
		}

		public void PauseInput(bool newPauseState) {
			pause = newPauseState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		public void stopMoving() {
			stopMove();
			look = Vector2.zero;
			jump = false;
			sprint = false;
			interact = false;
		}
		public void offMove() {
			canJump = false;
			canMove = false;
			canLook = false;
			canSprint = false;
			canInteract = false;
		}
		public void offMoveTotal() {
			offMove();
			canPause = false;
		}
		public void onMove() {
			canJump = true;
			canMove = true;
			canLook = true;
			canSprint = true;
			canInteract = true;
			canPause = true;
		}
		public void autoMove(Vector2 direction) {
			move = direction;
		}
		public void stopMove() {
			move = Vector2.zero;
		}
	}
	
}