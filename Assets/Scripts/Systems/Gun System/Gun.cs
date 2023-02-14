using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using NaughtyAttributes;

namespace Underground.Systems.GunSystem
{
    using Data;
    using System.Collections;

    sealed class Gun : MonoBehaviour
    {
        public bool HaveModule { get; private set; } = false;
        public int ShotBullets { get; private set; } = 0;

        [field: SerializeField]
        public GunData GunData { get; set; } = null;

        [SerializeField] private GunData m_DefaultGunData = null;
        [SerializeField] private Transform m_FirePoint = null;
        [SerializeField] private Transform m_DropPoint = null;
        [SerializeField] private Transform m_PoolPoint = null;
        [SerializeField] private AudioSource m_ShootSound = null;
        [SerializeField] private SpriteRenderer m_GunRenderer = null;

        [SerializeField] private bool m_ShakeCamera = true;

        private const string k_CameraShake = "Camera Shake";

        [SerializeField, Foldout(k_CameraShake), ShowIf(nameof(m_ShakeCamera))] private float m_Intensity = 5f;
        [SerializeField, Foldout(k_CameraShake), ShowIf(nameof(m_ShakeCamera))] private float m_Time = 0.1f;

        [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "<Pending>")]
        private Coroutine _currentCoroutine = null;

        private GameObject _module = null;

        public void Shoot()
        {
            _currentCoroutine ??= StartCoroutine(ShootWithDelay());
        }

        private IEnumerator ShootWithDelay()
        {
            ShotBullets++;

            Bullet bullet = Instantiate(GunData.BulletPrefab, m_FirePoint.position, m_FirePoint.rotation).GetComponent<Bullet>();
            bullet.Sender = gameObject;

            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(m_FirePoint.right * GunData.BulletForce, ForceMode2D.Impulse);

            Destroy(bullet, GunData.BulletLifetime);

            if (m_ShootSound != null)
                m_ShootSound.Play();

            if (m_ShakeCamera)
                CameraShake.Instance.ShakeCamera(m_Intensity, m_Time);

            yield return new WaitForSeconds(GunData.FireRate);
            _currentCoroutine = null;
        }

        public void SetModule(GunData gunData, GameObject module)
        {
            if (HaveModule)
            {
                _module.transform.position = m_DropPoint.position;
                _module.SetActive(true);
                module.SetActive(false);
                module.transform.position = m_PoolPoint.position;
            }
            else
            {
                module.SetActive(false);
                module.transform.position = m_PoolPoint.position;
            }

            _module = module;
            GunData = gunData;
            m_GunRenderer.sprite = gunData.Sprite;
            HaveModule = true;
        }

        public void RemoveModule()
        {
            if (!HaveModule)
                return;

            _module.transform.position = m_DropPoint.position;
            _module.SetActive(true);
            GunData = m_DefaultGunData;
            m_GunRenderer.sprite = m_DefaultGunData.Sprite;
            HaveModule = false;
        }
    }
}
