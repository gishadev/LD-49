using UnityEngine;

namespace Gisha.LD49.Core
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private float _followSpeed;
        [SerializeField] private Transform _target;

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            var newPosition = new Vector3(_target.transform.position.x, _target.transform.position.y,
                transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPosition, _followSpeed * Time.deltaTime);
        }
    }
}