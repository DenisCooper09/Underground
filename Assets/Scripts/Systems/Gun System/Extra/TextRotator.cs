using UnityEngine;

namespace Underground.Systems.GunSystem.Extra 
{
    sealed class TextRotator : MonoBehaviour
    {
        private void Update()
        {
            Quaternion rotation = transform.rotation;
            rotation.z = 0;
            transform.rotation = rotation;
        }
    }
}
