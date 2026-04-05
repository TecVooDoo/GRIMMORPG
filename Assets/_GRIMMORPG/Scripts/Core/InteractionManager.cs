using UnityEngine;
using UnityEngine.InputSystem;

namespace GRIMMORPG
{
    /// <summary>
    /// Manages hotspot detection and interaction via raycasting.
    /// Updates cursor on hover. Handles verb selection and execution.
    /// </summary>
    public sealed class InteractionManager : MonoBehaviour
    {
        public static InteractionManager Instance { get; private set; }

        [Header("Settings")]
        [SerializeField] private LayerMask _interactableMask = ~0;
        [SerializeField] private float _maxRayDistance = 50f;

        private Camera _mainCamera;
        private Hotspot _currentHotspot;
        private InteractionVerb _selectedVerb = InteractionVerb.None;

        public Hotspot CurrentHotspot => _currentHotspot;
        public InteractionVerb SelectedVerb => _selectedVerb;

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
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            UpdateHotspotDetection();
            HandleInteractionInput();
        }

        public void SelectVerb(InteractionVerb verb)
        {
            _selectedVerb = verb;
        }

        private void UpdateHotspotDetection()
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
                if (_mainCamera == null) return;
            }

            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = _mainCamera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxRayDistance, _interactableMask))
            {
                Hotspot hotspot = hit.collider.GetComponent<Hotspot>();

                if (hotspot != null && hotspot != _currentHotspot)
                {
                    _currentHotspot = hotspot;
                    CursorManager.Instance?.SetCursor(hotspot.HoverCursor);
                }
                else if (hotspot == null && _currentHotspot != null)
                {
                    ClearHotspot();
                }
            }
            else if (_currentHotspot != null)
            {
                ClearHotspot();
            }
        }

        private void HandleInteractionInput()
        {
            if (_currentHotspot == null)
                return;

            if (!Mouse.current.leftButton.wasPressedThisFrame)
                return;

            // If a verb is pre-selected, use it. Otherwise use default action.
            InteractionVerb verb = _selectedVerb != InteractionVerb.None
                ? _selectedVerb
                : GetDefaultVerb(_currentHotspot);

            ExecuteVerb(verb, _currentHotspot);

            // Reset verb after use
            _selectedVerb = InteractionVerb.None;
        }

        private void ExecuteVerb(InteractionVerb verb, Hotspot hotspot)
        {
            switch (verb)
            {
                case InteractionVerb.Look:
                    hotspot.Look();
                    break;
                case InteractionVerb.Use:
                    hotspot.Use();
                    break;
                case InteractionVerb.Talk:
                    hotspot.Talk();
                    break;
            }
        }

        private InteractionVerb GetDefaultVerb(Hotspot hotspot)
        {
            // Priority: Use > Talk > Look
            if (hotspot.CanUse) return InteractionVerb.Use;
            if (hotspot.CanTalk) return InteractionVerb.Talk;
            if (hotspot.CanLook) return InteractionVerb.Look;
            return InteractionVerb.Look;
        }

        private void ClearHotspot()
        {
            _currentHotspot = null;
            CursorManager.Instance?.ResetToDefault();
        }
    }

    public enum InteractionVerb
    {
        None,
        Look,
        Use,
        Talk
    }
}
