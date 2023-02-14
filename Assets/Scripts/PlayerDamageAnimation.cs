using UnityEngine;

namespace Underground
{
    sealed class PlayerDamageAnimation : MonoBehaviour
    {
        [SerializeField] private Animator m_PlayerAnsmator = null;

        public void PlayDamageAnimation()
        {
            m_PlayerAnsmator.SetTrigger("OnDamage");
        }
    }
}
