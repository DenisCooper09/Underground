using UnityEngine;

namespace Underground.Systems.CoinsSystem
{
    sealed class MoneyGeneratorSpawner : MonoBehaviour
    {
        public static MoneyGeneratorSpawner Instance { get; private set; }

        [SerializeField] private GameObject m_MoneyGeneratorPrefab = null;
        [SerializeField] private float m_Lifetime = 10f;

        private void Awake()
        {
            Instance = this;
        }

        public void Spawn(Transform point)
        {
            GameObject money = Instantiate(m_MoneyGeneratorPrefab, point.position, Quaternion.identity, transform);
            money.SetActive(true);
            Destroy(money, m_Lifetime);
        }
    }
}
