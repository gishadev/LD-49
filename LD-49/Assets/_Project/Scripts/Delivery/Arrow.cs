using UnityEngine;

namespace Gisha.LD49.Delivery
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float arrowDistance = 1.5f;

        private Transform _target;
        private Transform _parent;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _parent = transform.parent;
        }

        private void OnEnable()
        {
            EmbarkationManager.SpawnedPointOfInterest += SetTarget;
        }

        private void OnDisable()
        {
            EmbarkationManager.SpawnedPointOfInterest -= SetTarget;
        }

        private void Update()
        {
            if (_target == null)
            {
                _lineRenderer.enabled = false;
                return;
            }

            Vector2 dir = transform.InverseTransformDirection((_target.transform.position - _parent.transform.position)
                .normalized);
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(1, dir * arrowDistance);
        }

        private void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}