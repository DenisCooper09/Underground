using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Underground 
{
    using Systems.GunSystem;

    sealed class DieScreen : MonoBehaviour
    {
        [SerializeField] private Gun m_Gun = null;
        [SerializeField] private WavesSpawner m_WavesSpawner = null;
        [SerializeField] private TextMeshProUGUI m_WavesDefeatedText = null;
        [SerializeField] private TextMeshProUGUI m_ShotBulletsText = null;
        [SerializeField] private TextMeshProUGUI m_EnemiesKilledText = null;

        public void UpdateDieScreenData()
        {
            m_WavesDefeatedText.text = $"Waves Defeated: {m_WavesSpawner.CurrentWave}";
            m_ShotBulletsText.text = $"Shot Bullets: {m_Gun.ShotBullets}";
            m_EnemiesKilledText.text = $"Enemies Killed: {m_WavesSpawner.TotalKilledEnemies}";
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
