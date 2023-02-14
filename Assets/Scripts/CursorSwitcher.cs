using UnityEngine;

namespace Underground
{
    sealed class CursorSwitcher : MonoBehaviour
    {
        [SerializeField] private Texture2D m_Cursor = null;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SetCursor(m_Cursor);
        }

        public void SetCursor(Texture2D cursor)
        {
            Vector2 hotspot = new(cursor.width / 2, cursor.height / 2);
            Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
        }
    }
}
