using UnityEngine;

namespace Underground.Systems.GunSystem
{
    sealed class GunHolder : MonoBehaviour
    {
        public void Aim(Vector2 pointerPosition)
        {
            Vector2 aimDirection = (pointerPosition - (Vector2)transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, angle);

            Vector2 scale = Vector2.one;
            scale.y = angle > 90f || angle < -90f ? -1f : 1f;
            transform.localScale = scale;
        }
    }
}
