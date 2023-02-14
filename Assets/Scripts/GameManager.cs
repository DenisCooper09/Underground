using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Underground
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnSceneLoaded;

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(3f);
            OnSceneLoaded?.Invoke();
        }
    }
}
