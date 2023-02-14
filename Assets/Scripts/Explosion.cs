using UnityEngine;

namespace Underground
{
    sealed class Explosion : MonoBehaviour
    {
        public void DestroyOnEnd()
        {
            Destroy(gameObject);
        }
    }
}
