using System;
using UnityEngine;

namespace Gisha.LD49.Core
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private float _followSpeed;
        [SerializeField] private Transform _target;

        private Vector3 _minBound, _maxBound;
        private float _camHalfHeigth;
        private float _camHalfWidth;

        private void Start()
        {
            _minBound = WorldBounds.GetMinBound();
            _maxBound = WorldBounds.GetMaxBound();

            _camHalfHeigth = Camera.main.orthographicSize;
            _camHalfWidth = _camHalfHeigth * Screen.width / Screen.height;
        }

        private void Update()
        {
            FollowTarget();
            MoveIntoBounds();
        }

        private void FollowTarget()
        {
            var newPosition = new Vector3(_target.transform.position.x, _target.transform.position.y,
                transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPosition, _followSpeed * Time.deltaTime);
        }

        private void MoveIntoBounds()
        {
            var position = transform.position;

            float xPos = position.x;
            float yPos = position.y;

            if (position.x + _camHalfWidth > _maxBound.x)
                xPos = _maxBound.x - _camHalfWidth;
            if (position.x - _camHalfWidth < _minBound.x)
                xPos = _minBound.x + _camHalfWidth;
            if (position.y + _camHalfHeigth > _maxBound.y)
                yPos = _maxBound.y - _camHalfHeigth;
            if (position.y - _camHalfHeigth < _minBound.y)
                yPos = _minBound.y + _camHalfHeigth;

            transform.position = new Vector3(xPos, yPos, transform.position.z);
        }
    }
}