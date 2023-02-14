using System.Collections;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

namespace Underground
{
    public sealed class WavesSpawner : MonoBehaviour
    {
        public int CurrentWave { get; private set; } = 0;
        public int TotalKilledEnemies { get; private set; } = 0;

        [SerializeField, Min(1)] private int m_WaveTimer = 5;
        [SerializeField, Min(1)] private int m_WavesCount = 5;
        [SerializeField, MinMaxSlider(1, 100)] private Vector2Int m_EnemiesPerWave = new(10, 20);
        [SerializeField] private GameObject m_EnemyPrefab = null;
        [SerializeField] private Transform m_TopLeftPoint = null;
        [SerializeField] private Transform m_BottomRightPoint = null;

        [SerializeField] private Transform m_Point = null;
        [SerializeField] private Transform m_Player = null;
        [SerializeField] private TradeRoom m_TradeRoom = null;
        [SerializeField] private GameObject m_Gate1 = null;
        [SerializeField] private GameObject m_Gate2 = null;
        [SerializeField] private Counter m_CounterSELL = null;

        private const string k_UI = "UI";

        [SerializeField, BoxGroup(k_UI)] private TextMeshProUGUI m_CounterText = null;
        [SerializeField, BoxGroup(k_UI)] private Animator m_CounterTextAnimator = null;
        [SerializeField, BoxGroup(k_UI)] private TextMeshProUGUI m_WaveText = null;
        [SerializeField, BoxGroup(k_UI)] private Animator m_WaveUIAnimator = null;
        
        private int _killedEnemies = 0;
        private int _enemiesAmount = 0;

        private void Awake()
        {
            StartCoroutine(WaitBeforeSpawn());
        }

        public void OnEnemyKill()
        {
            _killedEnemies++;
            Debug.Log(_killedEnemies);
            TotalKilledEnemies++;

            if (_killedEnemies == _enemiesAmount)
            {
                CurrentWave++;
                _killedEnemies = 0;

                if (CurrentWave == m_WavesCount)
                {
                    m_CounterText.text = string.Empty; 
                    Destroy(m_CounterText);
                    return;
                }
                StartCoroutine(WaitBeforeSpawn());
            }
        }

        private IEnumerator WaitBeforeSpawn()
        {
            _enemiesAmount = Random.Range(m_EnemiesPerWave.x, m_EnemiesPerWave.y);
            Debug.Log(_enemiesAmount);

            m_Gate1.SetActive(false);
            m_Gate2.SetActive(false);
            m_CounterSELL.SpawnItems();

            m_WaveText.text = "Wave " + (CurrentWave + 1);
            m_WaveUIAnimator.SetBool("IsOut", false);

            for (int i = m_WaveTimer; i >= 0; i--)
            {
                m_CounterTextAnimator.SetTrigger("Trigger");
                m_CounterText.text = $"{i}";
                yield return new WaitForSeconds(1f);
            }

            m_CounterTextAnimator.SetTrigger("EndTrigger");
            m_WaveUIAnimator.SetBool("IsOut", true);
            yield return new WaitForSeconds(0.5f);
            m_CounterText.text = string.Empty;

            m_Gate1.SetActive(true);
            m_Gate2.SetActive(true);

            if (m_TradeRoom.HavePlayer)
            {
                m_Player.transform.position = m_Point.position;
            }

            SpawnWave();
        }

        private void SpawnWave()
        {
            for (int i = 0; i < _enemiesAmount; i++)
            {
                int x = Random.Range((int)m_TopLeftPoint.position.x, (int)m_BottomRightPoint.position.x);
                int y = Random.Range((int)m_TopLeftPoint.position.y, (int)m_BottomRightPoint.position.y);
                GameObject enemy = Instantiate(m_EnemyPrefab, new Vector2(x, y), Quaternion.identity, gameObject.transform);
                enemy.SetActive(true);
            }
        }
    }
}
