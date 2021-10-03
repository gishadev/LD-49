using System;
using UnityEngine;

namespace Gisha.LD49.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TaxiController : MonoBehaviour
    {
        [Header("Car settings")] [SerializeField]
        private float _maxSpeed = 20f;

        [SerializeField] private float _accelerationFactor = 30f;
        [SerializeField] private float _turnFactor = 3.5f;
        [SerializeField] private float _driftFactor = 0.95f;

        private float _velocityVsUp;
        private float _accelerationInput;
        private float _steeringInput;
        private float _rotationAngle;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
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
        }

        private void ApplyEngineForce()
        {
            // Calculate how much "forward" we are going in terms of the direction of our velocity.
            _velocityVsUp = Vector2.Dot(transform.up, _rb.velocity);

            // Limit speed.
            if (_velocityVsUp > _maxSpeed && _accelerationInput > 0)
                return;

            if (_velocityVsUp < -_maxSpeed * 0.5f && _accelerationInput < 0)
                return;

            // Limit so we cannot go faster in any direction while accelerating.
            if (_rb.velocity.sqrMagnitude > _maxSpeed * _maxSpeed && _accelerationInput > 0)
                return;

            // Apply drag, when there is no input.
            if (_accelerationInput == 0)
                _rb.drag = Mathf.Lerp(_rb.drag, 3f, Time.fixedDeltaTime * 3f);
            else _rb.drag = 0;

            Vector2 engineForce = transform.up * _accelerationInput * _accelerationFactor;
            _rb.AddForce(engineForce, ForceMode2D.Force);
        }

        private void ApplySteering()
        {
            // Limit the cars ability to turn when it moves slowly.
            float minSpeedBeforeAllowTurningFactor = _rb.velocity.magnitude / 8f;
            minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

            _rotationAngle -= _steeringInput * _turnFactor * minSpeedBeforeAllowTurningFactor;
            _rb.MoveRotation(_rotationAngle);
        }

        private void RemoveSideForces()
        {
            Vector2 forwardVel = transform.up * Vector2.Dot(_rb.velocity, transform.up);
            Vector2 rightVel = transform.right * Vector2.Dot(_rb.velocity, transform.right);

            _rb.velocity = forwardVel + rightVel * _driftFactor;
        }
    }
}