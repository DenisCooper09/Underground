using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using UnityEngine.UI;
using TMPro;

namespace Underground.Systems.FundamentalSystems
{
    public sealed class HealthSystem : MonoBehaviour
    {
        public bool CanTakeDamage { get; set; } = true;

        [SerializeField] private int m_MaxHealth = 100;
        [SerializeField] private int m_StartHealth = 100;
        [SerializeField] private bool m_DestroyOnDie = false;
        [SerializeField] private GameObject m_DamageText;
        [SerializeField] private Transform m_DamageTextPosition;

        [SerializeField] private bool m_UseUI = false;

        [SerializeField, ShowIf(nameof(m_UseUI))] private Slider m_HealthBar = null;
        [SerializeField, ShowIf(nameof(m_UseUI))] private Animator m_HealthBarAnimator = null;
        [SerializeField, ShowIf(nameof(m_UseUI))] private TextMeshProUGUI m_Text = null;

        private const string k_UnityEvents = "Unity Events";

        [SerializeField, Foldout(k_UnityEvents)] private UnityEvent OnTakeDamage, OnDie;
        private int _currentHealth = 0;
        private bool _isDead = false;

        private void Awake()
        {
            _currentHealth = m_StartHealth;
            if (m_UseUI)
            {
                m_Text.text = $"{_currentHealth}/{m_MaxHealth}";
                m_HealthBarAnimator.SetTrigger("Trigger");
                m_HealthBar.value = _currentHealth;
            }
        }

        public void TakeDamage(int damage, GameObject sender)
        {
            if (_isDead)
                return;
            if (sender != null && sender.layer == gameObject.layer)
                return;
            if (!CanTakeDamage)
                return;

            _currentHealth -= damage;
            GameObject textInstance = Instantiate(m_DamageText, m_DamageTextPosition.position, Quaternion.identity, m_DamageTextPosition.transform);
            textInstance.GetComponent<TextMeshPro>().text = damage.ToString();

            if (_currentHealth > 0)
            {
                OnTakeDamage?.Invoke();
                if (m_UseUI)
                {
                    m_Text.text = $"{_currentHealth}/{m_MaxHealth}";
                    m_HealthBarAnimator.SetTrigger("Trigger");
                    m_HealthBar.value = _currentHealth;
                }
            }
            else
            {
                OnDie?.Invoke();

                if (m_UseUI)
                {
                    m_Text.text = $"{0}/{0}";
                    m_HealthBarAnimator.SetTrigger("Trigger");
                    m_HealthBar.value = 0f;
                }

                _isDead = true;
                if (m_DestroyOnDie)
                    Destroy(gameObject);
            }
        }

        public void AddHealth(int amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, 100);
            if (m_UseUI)
            {
                m_Text.text = $"{_currentHealth}/{m_MaxHealth}";
                m_HealthBarAnimator.SetTrigger("Trigger");
                m_HealthBar.value = _currentHealth;
            }
        }
    }
}
