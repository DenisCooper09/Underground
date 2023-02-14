using UnityEngine;

namespace Underground
{
    sealed class TradeRoom : MonoBehaviour
    {
        public bool HavePlayer { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null && collision.CompareTag("Player"))
            {
                HavePlayer = true;
                Debug.Log("Player in a trade room.");
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision != null && collision.CompareTag("Player"))
            {
                HavePlayer = false;
                Debug.Log("Player out of a trade room.");
            }
        }
    }
}
