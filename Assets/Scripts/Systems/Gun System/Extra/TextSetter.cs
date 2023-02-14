using UnityEngine;
using TMPro;

namespace Underground.Systems.GunSystem.Extra
{
    using Data;

    sealed class TextSetter : MonoBehaviour
    {
        [SerializeField] private TextMeshPro m_Text = null;
        [SerializeField] private GunData m_Data = null;

        private void Awake()
        {
            m_Text.text = m_Data.Damage.ToString();
        }
    }
}
