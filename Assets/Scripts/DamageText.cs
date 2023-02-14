using UnityEngine;

namespace Underground
{
    sealed class DamageText : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
