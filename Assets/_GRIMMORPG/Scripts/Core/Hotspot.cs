using UnityEngine;
using UnityEngine.Events;

namespace GRIMMORPG
{
    /// <summary>
    /// Marks a GameObject as an interactive hotspot in the point-and-click world.
    /// Provides cursor feedback on hover and fires events on interaction.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class Hotspot : MonoBehaviour
    {
        [Header("Display")]
        [SerializeField] private string _displayName = "Object";
        [TextArea(2, 4)]
        [SerializeField] private string _description = "";

        [Header("Allowed Interactions")]
        [SerializeField] private bool _canLook = true;
        [SerializeField] private bool _canUse;
        [SerializeField] private bool _canTalk;

        [Header("Default Cursor On Hover")]
        [SerializeField] private CursorType _hoverCursor = CursorType.Look;

        [Header("Events")]
        [SerializeField] private UnityEvent _onLook;
        [SerializeField] private UnityEvent _onUse;
        [SerializeField] private UnityEvent _onTalk;

        public string DisplayName => _displayName;
        public string Description => _description;
        public bool CanLook => _canLook;
        public bool CanUse => _canUse;
        public bool CanTalk => _canTalk;
        public CursorType HoverCursor => _hoverCursor;

        public void Look()
        {
            if (_canLook)
                _onLook?.Invoke();
        }

        public void Use()
        {
            if (_canUse)
                _onUse?.Invoke();
        }

        public void Talk()
        {
            if (_canTalk)
                _onTalk?.Invoke();
        }
    }
}
