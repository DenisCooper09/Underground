using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

namespace Underground
{
    sealed class PlayerInput : MonoBehaviour
    {
        [field: SerializeField]
        public Camera Camera { get; set; } = null;

        private const string k_UnityEvents = "Unity Events";

        [SerializeField, Foldout(k_UnityEvents)] private UnityEvent<Vector2> OnMovementInput, OnPointerInput;
        [SerializeField, Foldout(k_UnityEvents)] private UnityEvent OnShoot, OnDrop;

        private PlayerInputActions _playerInputActions = null;

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
        }

        private void Update()
        {
            OnMovementInput?.Invoke(_playerInputActions.Player.Movement.ReadValue<Vector2>());
            OnPointerInput?.Invoke(GetPointerInput());

            if (Input.GetMouseButton(0))
                OnShoot.Invoke();

            if (Input.GetKeyDown(KeyCode.Q))
                OnDrop?.Invoke();
        }

        private Vector2 GetPointerInput()
        {
            return (Vector2)Camera.ScreenToWorldPoint(_playerInputActions.Player.PointerPosition.ReadValue<Vector2>());
        }
    }
}
