using UnityEngine;

namespace Underground
{
    using Systems.FundamentalSystems;
    using Systems.FundamentalSystems.InteractionSystem;

    sealed class HealthPot : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject m_Main = null;
        [SerializeField] private GameObject m_UI = null;
        [SerializeField] private int m_HealthAmount = 15;
        [SerializeField] private HealthSystem m_HealthSystem = null;

        public GameObject GetUI()
        {
            return m_UI;
        }

        public void Interact()
        {
            m_HealthSystem.AddHealth(m_HealthAmount);   
            Destroy(m_Main);
        }
    }
}
