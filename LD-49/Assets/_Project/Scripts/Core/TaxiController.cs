using UnityEngine;

namespace Gisha.LD49.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TaxiController : MonoBehaviour
    {
        [Header("Car settings")] [SerializeField]
        private float maxSpeed = 20f;

        [SerializeField] private float accelerationFactor = 8f;
        [SerializeField] private float turnFactor = 4f;
        [SerializeField] private float driftFactor = 0.3f;
        
        [SerializeField] private float passiveDrag = 3f;
        [SerializeField] private float passiveDragSpeed = 3f;
        
        public int ConvertedSpeed => Mathf.Abs(Mathf.RoundToInt(_velocityVsUp / maxSpeed * 120));

        private Vector3 _maxBound, _minBound;
        private float _halfWidth, _halfHeight;

        private float _velocityVsUp;
        private float _accelerationInput;
        private float _steeringInput;
        private float _rotationAngle;

        private Rigidbody2D _rb;
        private BoxCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _maxBound = WorldBounds.GetMaxBound();
            _minBound = WorldBounds.GetMinBound();
            _halfWidth = _collider.size.x / 2;
            _halfHeight = _collider.size.y / 2;
        }

        private void Update()
        {
            _accelerationInput = Input.GetAxis("Vertical");
            _steeringInput = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            ApplyEngineForce();

            RemoveSideForces();

            ApplySteering();

            MoveIntoBounds();
        }

        private void ApplyEngineForce()
        {
            // Calculate how much "forward" we are going in terms of the direction of our velocity.
            _velocityVsUp = Vector2.Dot(transform.up, _rb.velocity);

            // Limit speed.
            if (_velocityVsUp > maxSpeed && _accelerationInput > 0)
                return;

            if (_velocityVsUp < -maxSpeed * 0.6f && _accelerationInput < 0)
                return;

            // Limit so we cannot go faster in any direction while accelerating.
            if (_rb.velocity.sqrMagnitude > maxSpeed * maxSpeed && _accelerationInput > 0)
                return;

            // Apply drag, when there is no input.
            if (_accelerationInput == 0)
                _rb.drag = Mathf.Lerp(_rb.drag, passiveDrag, Time.fixedDeltaTime * passiveDragSpeed);
            else _rb.drag = 0;

            Vector2 engineForce = transform.up * _accelerationInput * accelerationFactor;
            _rb.AddForce(engineForce, ForceMode2D.Force);
        }

        private void ApplySteering()
        {
            // Limit the cars ability to turn when it moves slowly.
            float minSpeedBeforeAllowTurningFactor = _rb.velocity.magnitude / 8f;
            minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

            _rotationAngle -= _steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
            _rb.MoveRotation(_rotationAngle);
        }

        private void RemoveSideForces()
        {
            Vector2 forwardVel = transform.up * Vector2.Dot(_rb.velocity, transform.up);
            Vector2 rightVel = transform.right * Vector2.Dot(_rb.velocity, transform.right);

            _rb.velocity = forwardVel + rightVel * driftFactor;
        }

        private void MoveIntoBounds()
        {
            var position = transform.position;

            float xPos = position.x;
            float yPos = position.y;

            if (position.x + _halfWidth > _maxBound.x)
                xPos = _maxBound.x - _halfWidth;
            if (position.x - _halfWidth < _minBound.x)
                xPos = _minBound.x + _halfWidth;
            if (position.y + _halfHeight > _maxBound.y)
                yPos = _maxBound.y - _halfHeight;
            if (position.y - _halfHeight < _minBound.y)
                yPos = _minBound.y + _halfHeight;

            _rb.position = new Vector2(xPos, yPos);
        }
    }
}