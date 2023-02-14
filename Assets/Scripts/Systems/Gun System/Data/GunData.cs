using System;
using UnityEngine;
using NaughtyAttributes;
using Random = UnityEngine.Random;

namespace Underground.Systems.GunSystem.Data
{
    [CreateAssetMenu(fileName = "GunData_", menuName = "Scriptable Objects/Gun Data", order = 1)]
    sealed class GunData : ScriptableObject
    {
        private const string k_Weapon = "Weapon";

        public int Damage 
        {
            get
            {
                return Random.Range(m_Damage.x, m_Damage.y);
            }
        }

        [SerializeField, BoxGroup(k_Weapon), MinMaxSlider(1, 100)]
        private Vector2Int m_Damage = new(10, 10);

        [field: SerializeField, BoxGroup(k_Weapon), Range(0.05f, 5f)]
        public float FireRate { get; private set; } = 0.4f;

        [field: SerializeField, BoxGroup(k_Weapon), ShowAssetPreview(128, 128)]
        public Sprite Sprite { get; private set; } = null;

        [SerializeField, BoxGroup(k_Weapon)] private bool m_HaveModule = true;

        [field: SerializeField, BoxGroup(k_Weapon), ShowAssetPreview(128, 128), ShowIf(nameof(m_HaveModule))]
        public GameObject ModulePrefab { get; private set; } = null;

        private const string k_Bullet = "Bullet";

        [field: SerializeField, BoxGroup(k_Bullet)]
        public int BulletForce { get; private set; } = 50;

        [field: SerializeField, BoxGroup(k_Bullet), Range(1, 15)]
        public int BulletLifetime { get; private set; } = 5;

        [field: SerializeField, BoxGroup(k_Bullet)]
        public GameObject BulletPrefab { get; private set; } = null;
    }
}
