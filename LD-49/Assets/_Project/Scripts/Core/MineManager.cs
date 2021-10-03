using System.Collections;
using UnityEngine;

namespace Gisha.LD49.Core
{
    public class MineManager : MonoBehaviour
    {
        private static MineManager Instance { get; set; }

        [SerializeField] private TaxiController taxiController;
        [SerializeField] private float minSafeSpeed;
        [SerializeField] private float explodeDelayInSeconds;
        public static bool IsSafe => Instance.TaxiSpeed > Instance.minSafeSpeed;

        private float TaxiSpeed => taxiController.ConvertedSpeed;

        private float _delay;

        private void Awake()
        {
            Instance = this;
            _delay = explodeDelayInSeconds;
        }

        private void Update()
        {
            if (!IsSafe)
            {
                _delay -= Time.deltaTime;
                if (_delay < 0f)
                    Explode();
            }

            else
                _delay = explodeDelayInSeconds;
        }

        private void Explode()
        {
            Debug.Log("<color=red>KABOOM!</color>");
        }
    }
}