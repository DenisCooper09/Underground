using UnityEngine;

namespace Underground.Systems.GunSystem.Extra
{
    sealed class BananaRotator : MonoBehaviour
    {
        [SerializeField] private float m_RotationSpeed = 360f;

        private void Update()
        {
            transform.Rotate(new Vector3(0f, 0f, m_RotationSpeed * Time.deltaTime));
        }
    }
}
