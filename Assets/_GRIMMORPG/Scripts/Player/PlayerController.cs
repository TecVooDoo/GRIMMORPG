using UnityEngine;
using UnityEngine.AI;
using Animancer;

namespace GRIMMORPG
{
    /// <summary>
    /// Click-to-move player controller for point-and-click gameplay.
    /// Uses NavMeshAgent for pathfinding and Animancer for animation.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(AnimancerComponent))]
    public sealed class PlayerController : MonoBehaviour
    {
        [Header("Animation")]
        [SerializeField] private ClipTransition _idleClip;
        [SerializeField] private ClipTransition _walkClip;

        [Header("Movement")]
        [SerializeField] private float _stoppingDistance = 0.15f;
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private LayerMask _walkableMask = ~0;

        private NavMeshAgent _agent;
        private AnimancerComponent _animancer;
        private Camera _mainCamera;
        private bool _isMoving;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animancer = GetComponent<AnimancerComponent>();
            _mainCamera = Camera.main;

            _agent.stoppingDistance = _stoppingDistance;
            _agent.updateRotation = false;
        }

        private void Start()
        {
            PlayIdle();
        }

        private void Update()
        {
            HandleClickInput();
            HandleMovementAnimation();
            HandleRotation();
        }

        private void HandleClickInput()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            // Don't move if clicking on a hotspot — InteractionManager handles those
            if (InteractionManager.Instance != null && InteractionManager.Instance.CurrentHotspot != null)
                return;

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, _walkableMask))
            {
                MoveTo(hit.point);
            }
        }

        public void MoveTo(Vector3 destination)
        {
            _agent.SetDestination(destination);
            _isMoving = true;
        }

        public void Stop()
        {
            _agent.ResetPath();
            _isMoving = false;
            PlayIdle();
        }

        private void HandleMovementAnimation()
        {
            if (!_isMoving)
                return;

            bool hasReachedDestination = !_agent.pathPending
                && _agent.remainingDistance <= _agent.stoppingDistance
                && (!_agent.hasPath || _agent.velocity.sqrMagnitude < 0.01f);

            if (hasReachedDestination)
            {
                _isMoving = false;
                PlayIdle();
            }
            else
            {
                PlayWalk();
            }
        }

        private void HandleRotation()
        {
            if (_agent.velocity.sqrMagnitude < 0.01f)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                _rotationSpeed * Time.deltaTime
            );
        }

        private void PlayIdle()
        {
            if (_idleClip != null && _idleClip.Clip != null)
            {
                _animancer.Play(_idleClip);
            }
        }

        private void PlayWalk()
        {
            if (_walkClip != null && _walkClip.Clip != null)
            {
                _animancer.Play(_walkClip);
            }
        }
    }
}
