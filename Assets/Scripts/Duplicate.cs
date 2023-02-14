using UnityEngine;

namespace Underground
{
    sealed class Duplicate : MonoBehaviour
    {
        public static Duplicate Instance { get; private set; } = null;

        [SerializeField] private GameObject m_ObjectToDuplicate = null;
        [SerializeField] private int m_Times = 10;
        [SerializeField] private bool m_DuplicateOnAwake = true;

        private void Awake()
        {
            Instance = this;

            if (!m_DuplicateOnAwake)
                return;

            DuplicateObject(m_ObjectToDuplicate, m_Times);
        }

        public void DuplicateObject(GameObject objectToDuplicate, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Instantiate(objectToDuplicate, gameObject.transform);
            }
        }
    }
}
