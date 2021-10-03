using System;
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

        public static Transform GetMaxBound() => Instance.max;
        public static Transform GetMinBound() => Instance.min;
    }
}