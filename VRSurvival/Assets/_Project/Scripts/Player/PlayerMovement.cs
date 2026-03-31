using UnityEngine;
using Unity.XR.CoreUtils;

namespace VRSurvival.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 1.5f;

        private XROrigin _xrOrigin;
        private CharacterController _characterController;
        private Vector2 _moveInput;

        private void Awake()
        {
            _xrOrigin = GetComponent<XROrigin>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            HandleMovement();
            ApplyGravity();
        }

        private void HandleMovement()
        {
            if (_moveInput == Vector2.zero) return;

            Transform head = _xrOrigin.Camera.transform;
            Vector3 forward = new Vector3(head.forward.x, 0, head.forward.z).normalized;
            Vector3 right = new Vector3(head.right.x, 0, head.right.z).normalized;

            Vector3 moveDirection = (forward * _moveInput.y + right * _moveInput.x) * moveSpeed * Time.deltaTime;
            _characterController.Move(moveDirection);
        }

        private void ApplyGravity()
        {
            if (!_characterController.isGrounded)
                _characterController.Move(Vector3.down * 9.81f * Time.deltaTime);
        }

        public void SetMoveInput(Vector2 input) => _moveInput = input;
    }
}