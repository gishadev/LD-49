using UnityEngine;

namespace Gisha.LD49.Core
{
    public class WorldBounds : MonoBehaviour
    {
        private static WorldBounds Instance { get; set; }

        [SerializeField] private Transform max;
        [SerializeField] private Transform min;

        private void Awake()
        {
            Instance = this;
        }

        public static Vector2 GetMaxBound() => Instance.max.position;
        public static Vector2 GetMinBound() => Instance.min.position;
    }
}