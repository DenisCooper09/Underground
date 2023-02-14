using UnityEngine;
using UnityEngine.Rendering.Universal;
using NaughtyAttributes;

namespace Underground
{
    sealed class LightSetter : MonoBehaviour
    {
        [SerializeField]
        private float m_ON = 1f, m_OFF = 0.25f;

        [Button]
        public void On()
        {
            GetComponent<Light2D>().intensity = m_ON;
        }

        [Button]
        public void Off()
        {
            GetComponent<Light2D>().intensity = m_OFF;
        }
    }
}
