using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gisha.LD49.Delivery
{
    public class EmbarkationManager : MonoBehaviour
    {
        [SerializeField] private GameObject passengerPrefab;
        [SerializeField] private GameObject destinationSpotPrefab;

        // Using for arrow object, which shows next passenger/destination spot.
        public static Action<Transform> SpawnedPointOfInterest;

        public Passenger CPassenger { get; private set; }

        private PassengerSpot[] _passengerSpots;

        private void OnEnable()
        {
            EmbarkDisembarkChecker.PassengerEmbarked += OnPassengerEmbarked;
            EmbarkDisembarkChecker.PassengerDisembarked += OnPassengerDisembarked;
        }

        private void OnDisable()
        {
            EmbarkDisembarkChecker.PassengerEmbarked -= OnPassengerEmbarked;
            EmbarkDisembarkChecker.PassengerDisembarked -= OnPassengerDisembarked;
        }

        private void Awake()
        {
            _passengerSpots = FindObjectsOfType<PassengerSpot>();
        }

        private void Start()
        {
            SpawnPassengerAtRandomSpot();
        }

        private void OnPassengerEmbarked()
        {
            SpawnDestinationSpot();
        }

        private void OnPassengerDisembarked()
        {
            SpawnPassengerAtRandomSpot();
        }

        private void SpawnPassengerAtRandomSpot()
        {
            GeneratePassengerSpots(out PassengerSpot embarkSpot, out PassengerSpot destinationSpot);

            var passenger = Instantiate(passengerPrefab, embarkSpot.Position, Quaternion.identity)
                .GetComponent<Passenger>();
            passenger.SetDestinationSpot(destinationSpot);

            CPassenger = passenger;

            SpawnedPointOfInterest?.Invoke(passenger.transform);
        }

        private void SpawnDestinationSpot()
        {
            var spot = Instantiate(destinationSpotPrefab, CPassenger.DestinationSpot.Position, Quaternion.identity);
            SpawnedPointOfInterest?.Invoke(spot.transform);
        }

        private void GeneratePassengerSpots(out PassengerSpot embarkSpot, out PassengerSpot destinationSpot)
        {
            var spots = _passengerSpots.ToList();

            embarkSpot = _passengerSpots[Random.Range(0, spots.Count)];
            spots.Remove(embarkSpot);
            destinationSpot = _passengerSpots[Random.Range(0, spots.Count)];
        }
    }
}