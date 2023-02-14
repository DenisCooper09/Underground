using System.Collections.Generic;
using UnityEngine;

namespace Underground
{
    sealed class Counter : MonoBehaviour
    {
        [SerializeField] private Transform[] m_Points = null;
        [SerializeField] private GameObject[] m_Items = null;

        private readonly List<GameObject> _currentItems = new List<GameObject>();

        private void Awake()
        {
            SpawnItems();
        }

        public void SpawnItems()
        {
            for (int i = 0; i < _currentItems.Count; i++)
            {
                Destroy(_currentItems[i]);
            }

            for (int i = 0; i < m_Points.Length; i++)
            {
                GameObject item = Instantiate(m_Items[Random.Range(0, m_Items.Length)], m_Points[i].position, Quaternion.identity);
                item.SetActive(true);
                _currentItems.Add(item);
            }
        }
    }
}
