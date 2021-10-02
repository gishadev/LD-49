using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gisha.LD49
{
    public class PassengerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject passengerPrefab;
        private PassengerSpot[] _passengerSpots;

        private void OnEnable()
        {
            PassengerPicker.PassengerPicked += SpawnPassengerAtRandomSpot;
        }

        private void OnDisable()
        {
            PassengerPicker.PassengerPicked -= SpawnPassengerAtRandomSpot;
        }

        private void Awake()
        {
            _passengerSpots = FindObjectsOfType<PassengerSpot>();
        }

        private void Start()
        {
            SpawnPassengerAtRandomSpot();
        }

        private void SpawnPassengerAtRandomSpot()
        {
            var randomSpot = _passengerSpots[Random.Range(0, _passengerSpots.Length)];
            Instantiate(passengerPrefab, randomSpot.transform.position, Quaternion.identity);
        }
    }
}