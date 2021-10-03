using System;
using System.Linq;
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
            GeneratePassengerSpots(out PassengerSpot embarkSpot, out PassengerSpot disembarkSpot);

            var passenger = Instantiate(passengerPrefab, embarkSpot.transform.position, Quaternion.identity)
                .GetComponent<Passenger>();
            passenger.SetDisembarkSpot(disembarkSpot);
        }

        private void GeneratePassengerSpots(out PassengerSpot embarkSpot, out PassengerSpot disembarkSpot)
        {
            var spots = _passengerSpots.ToList();
            
            embarkSpot = _passengerSpots[Random.Range(0, spots.Count)];
            spots.Remove(embarkSpot);
            disembarkSpot = _passengerSpots[Random.Range(0, spots.Count)];
        }
    }
}