using UnityEngine;
using TMPro;

namespace Underground.Systems.CoinsSystem
{
    sealed class Wallet : MonoBehaviour
    {
        [field: SerializeField]
        public int Coins { get; private set; } = 0;

        [SerializeField] private TextMeshProUGUI m_BalanceText = null;

        private void Awake()
        {
            UpdateText();
        }

        public void CollectCoin()
        {
            Coins++;
            UpdateText();
        }

        public void TakeMoney(int amount)
        {
            Coins -= amount;
            UpdateText();
        }

        private void UpdateText()
        {
            m_BalanceText.text = Coins.ToString();
        }
    }
}
