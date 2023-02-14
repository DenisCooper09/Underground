using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Underground
{
    sealed class Cutscene : MonoBehaviour
    {
        public int SceneCount = 6;

        private int current = 0;

        private void Awake()
        {
            StartCoroutine(GoToNext());
            DontDestroyOnLoad(gameObject);
        }

        private IEnumerator GoToNext()
        {
            while (current < SceneCount)
            {
                yield return new WaitForSeconds(1f);

                if (current == SceneCount)
                {
                    yield return new WaitForSeconds(1f);
                }

                if (current == SceneCount)
                {
                    Destroy(gameObject);
                }

                current++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
