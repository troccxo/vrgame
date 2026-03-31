using UnityEngine;
using UnityEngine.InputSystem;

namespace VRSurvival.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Input Actions")]
        [SerializeField] private InputActionReference moveAction;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnEnable()
        {
            moveAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
        }

        private void Update()
        {
            Vector2 move = moveAction.action.ReadValue<Vector2>();
            _playerMovement.SetMoveInput(move);
        }
    }
}