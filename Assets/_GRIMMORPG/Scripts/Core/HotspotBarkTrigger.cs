using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace GRIMMORPG
{
    /// <summary>
    /// Bridge between the Hotspot system and Dialogue System barks.
    /// Attach to any GameObject with a Hotspot to make interactions
    /// trigger bark lines from a dialogue database.
    /// </summary>
    [RequireComponent(typeof(Hotspot))]
    public sealed class HotspotBarkTrigger : MonoBehaviour
    {
        [Header("Bark Settings")]
        [SerializeField] private string _lookBark = "";
        [SerializeField] private string _useBark = "";
        [SerializeField] private string _talkConversation = "";

        [Header("Speaker")]
        [SerializeField] private Transform _barkSource;

        private Hotspot _hotspot;

        private void Awake()
        {
            _hotspot = GetComponent<Hotspot>();

            if (_barkSource == null)
                _barkSource = transform;
        }

        private void OnEnable()
        {
            // Subscribe to hotspot events via UnityEvent in inspector
            // This script provides the methods that can be wired up
        }

        /// <summary>
        /// Wire this to Hotspot.OnLook in the inspector.
        /// Shows a bark line describing the object.
        /// </summary>
        public void BarkLookDescription()
        {
            if (!string.IsNullOrEmpty(_lookBark))
            {
                DialogueManager.BarkString(_lookBark, _barkSource);
            }
        }

        /// <summary>
        /// Wire this to Hotspot.OnUse in the inspector.
        /// Shows a bark line for using the object.
        /// </summary>
        public void BarkUseDescription()
        {
            if (!string.IsNullOrEmpty(_useBark))
            {
                DialogueManager.BarkString(_useBark, _barkSource);
            }
        }

        /// <summary>
        /// Wire this to Hotspot.OnTalk in the inspector.
        /// Starts a full dialogue conversation.
        /// </summary>
        public void StartConversation()
        {
            if (!string.IsNullOrEmpty(_talkConversation))
            {
                DialogueManager.StartConversation(_talkConversation, _barkSource);
            }
        }
    }
}
