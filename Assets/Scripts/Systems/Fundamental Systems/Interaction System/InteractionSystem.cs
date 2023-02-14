using UnityEngine;

namespace Underground.Systems.FundamentalSystems.InteractionSystem
{
    sealed class InteractionSystem : MonoBehaviour
    {
        [SerializeField] private LayerMask m_Layer = default;
        [SerializeField] private Transform m_Origin = null;
        [SerializeField] private float m_Radius = 1.25f;

        private IInteractable _lastInteractable = null;

        private void Update()
        {
            RaycastHit2D hit = Physics2D.CircleCast(
                m_Origin.transform.position,
                m_Radius,
                m_Origin.transform.position,
                m_Radius, 
                m_Layer);

            if (hit && hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                HideUI();

                _lastInteractable = interactable;

                ShowUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _lastInteractable.Interact();
                    HideUI();
                }

                return;
            }

            if (_lastInteractable != null)
                HideUI();
        }

        private void ShowUI()
        {
            if (_lastInteractable == null)
                return;

            GameObject ui = _lastInteractable.GetUI();

            if (ui == null)
                return;

            ui.SetActive(true);
        }

        private void HideUI()
        {
            if (_lastInteractable == null)
                return;

            GameObject ui = _lastInteractable.GetUI();

            if (ui == null)
                return;

            ui.SetActive(false);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(m_Origin.position, m_Radius);
        }
    }
}
