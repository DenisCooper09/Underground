using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

namespace Underground.Systems.FundamentalSystems
{
    [RequireComponent(typeof(Rigidbody2D))]
    sealed class MovementSystem : MonoBehaviour
    {
        public Vector2 MovementInput { get; set; } = Vector2.zero;

        [SerializeField, Min(0)]
        private float m_MaxSpeed = 4.5f, m_Acceleration = 3f, m_Deacceleration = 4f;

        [SerializeField] private bool m_UseDashing = true;

        private const string k_DashSettings = "Dash Settings";

        [SerializeField, Foldout(k_DashSettings), ShowIf(nameof(m_UseDashing))]
        private float m_DashingForce = 25f, m_DashingTime = 0.2f, m_DashingCooldown = 1f;

        [SerializeField, Foldout(k_DashSettings), ShowIf(nameof(m_UseDashing))]
        private TrailRenderer m_TrailRenderer = null;

        [SerializeField, Foldout(k_DashSettings), ShowIf(nameof(m_UseDashing))]
        private UnityEvent OnDashStarted, OnDashFinished;

        private bool _isDashing, _canDash = true;
        private float _currentSpeed = 0f;
        private Vector2 _oldMovementInput = Vector2.zero;
        private Rigidbody2D _rigidbody2d = null;

        private void Awake()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash && m_UseDashing)
                StartCoroutine(Dash());
        }

        private void FixedUpdate()
        {
            if (_isDashing && m_UseDashing)
                return;

            if (MovementInput.magnitude > 0f && _currentSpeed >= 0f)
            {
                _oldMovementInput = MovementInput;
                _currentSpeed += m_Acceleration * m_MaxSpeed * Time.deltaTime;
            }
            else _currentSpeed -= m_Deacceleration * m_MaxSpeed * Time.deltaTime;

            _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, m_MaxSpeed);
            _rigidbody2d.velocity = _oldMovementInput * _currentSpeed;
        }

        private IEnumerator Dash()
        {
            OnDashStarted?.Invoke();
            _canDash = false;
            _isDashing = true;
            _rigidbody2d.velocity = MovementInput.normalized * m_DashingForce;
            m_TrailRenderer.emitting = true;
            yield return new WaitForSeconds(m_DashingTime);
            m_TrailRenderer.emitting = false;
            _isDashing = false;
            OnDashFinished?.Invoke();
            yield return new WaitForSeconds(m_DashingCooldown);
            _canDash = true;
        }
    }
}
