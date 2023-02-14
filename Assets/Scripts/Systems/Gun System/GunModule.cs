using UnityEngine;

namespace Underground.Systems.GunSystem
{
    using Data;
    using FundamentalSystems.InteractionSystem;

    sealed class GunModule : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject m_UI = null, m_Module = null;
        [SerializeField] private GunData m_GunData = null;
        [SerializeField] private Gun m_Gun = null;

        public GameObject GetUI()
        {
            return m_UI;
        }

        public void Interact()
        {
            m_Gun.SetModule(m_GunData, m_Module);
        }
    }
}
