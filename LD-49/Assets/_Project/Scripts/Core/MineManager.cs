using System.Collections;
using UnityEngine;

namespace Gisha.LD49.Core
{
    public class MineManager : MonoBehaviour
    {
        [SerializeField] private TaxiController taxiController;
        [SerializeField] private float minCalmSpeed;
        [SerializeField] private float explodeDelayInSeconds;
        private float TaxiSpeed => taxiController.ConvertedSpeed;

        private float _delay;

        private void Awake()
        {
            _delay = explodeDelayInSeconds;
        }

        private void Update()
        {
            if (TaxiSpeed < minCalmSpeed)
            {
                _delay -= Time.deltaTime;
                if (_delay < 0f)
                    Explode();
            }
            else
            {
                _delay = explodeDelayInSeconds;
            }
        }

        private void Explode()
        {
            Debug.Log("<color=red>KABOOM!</color>");
        }
    }
}