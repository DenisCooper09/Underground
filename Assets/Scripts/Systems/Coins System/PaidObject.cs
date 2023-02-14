using UnityEngine;
using UnityEngine.Events;

namespace Underground.Systems.CoinsSystem
{
    using FundamentalSystems.InteractionSystem;
    using TMPro;

    sealed class PaidObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Wallet m_Wallet = null;
        [SerializeField] private GameObject m_UI = null;
        [SerializeField] private TextMeshPro m_PriceText = null;
        [SerializeField] private int m_Price = 100;
        [SerializeField] private UnityEvent OnBuy;

        private void Awake()
        {
            m_PriceText.text = $"'E' to buy\n{m_Price}";
        }

        public GameObject GetUI()
        {
            return m_UI;
        }

        public void Interact()
        {
            if (m_Wallet.Coins >= m_Price)
            {
                m_Wallet.TakeMoney(m_Price);
                OnBuy?.Invoke();
                Destroy(GetComponent<CircleCollider2D>());
                Destroy(this);
            }
        }
    }
}
