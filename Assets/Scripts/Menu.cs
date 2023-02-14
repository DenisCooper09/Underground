using UnityEngine;
using UnityEngine.SceneManagement;

namespace Underground
{
    sealed class Menu : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
