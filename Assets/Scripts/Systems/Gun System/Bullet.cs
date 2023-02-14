using UnityEngine;

namespace Underground.Systems.GunSystem
{
    using FundamentalSystems;
    using Data;

    sealed class Bullet : MonoBehaviour
    {
        public GameObject Sender { private get; set; }

        [SerializeField] private GunData m_WeaponData;
        [SerializeField] private GameObject m_ExplosionEffect;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null && collision.CompareTag("Trade Zone"))
                return;

            if (collision != null && collision.TryGetComponent(out HealthSystem healthSystem))
                healthSystem.TakeDamage(m_WeaponData.Damage, Sender);

            Instantiate(m_ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
