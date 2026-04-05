using UnityEngine;

namespace GRIMMORPG
{
    /// <summary>
    /// Manages hardware cursor appearance based on interaction context.
    /// Cursor textures are assigned in the inspector.
    /// </summary>
    public sealed class CursorManager : MonoBehaviour
    {
        public static CursorManager Instance { get; private set; }

        [Header("Cursor Textures")]
        [SerializeField] private Texture2D _defaultCursor;
        [SerializeField] private Texture2D _lookCursor;
        [SerializeField] private Texture2D _useCursor;
        [SerializeField] private Texture2D _talkCursor;
        [SerializeField] private Texture2D _walkCursor;

        [Header("Hotspot (tip of cursor)")]
        [SerializeField] private Vector2 _defaultHotspot = Vector2.zero;
        [SerializeField] private Vector2 _centeredHotspot = new Vector2(16f, 16f);

        private CursorType _currentType = CursorType.Default;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            SetCursor(CursorType.Default);
        }

        public void SetCursor(CursorType type)
        {
            if (_currentType == type)
                return;

            _currentType = type;

            Texture2D texture = type switch
            {
                CursorType.Look => _lookCursor,
                CursorType.Use => _useCursor,
                CursorType.Talk => _talkCursor,
                CursorType.Walk => _walkCursor,
                _ => _defaultCursor
            };

            Vector2 hotspot = type == CursorType.Default ? _defaultHotspot : _centeredHotspot;
            Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
        }

        public void ResetToDefault()
        {
            SetCursor(CursorType.Default);
        }
    }

    public enum CursorType
    {
        Default,
        Look,
        Use,
        Talk,
        Walk
    }
}
