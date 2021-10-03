using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gisha.LD49.Subject
{
    public class EmbarkationManager : MonoBehaviour
    {
        [SerializeField] private GameObject passengerPrefab;
        [SerializeField] private GameObject disembarkSpotPrefab;

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
            SpawnDisembarkSpot();
        }

        private void OnPassengerDisembarked()
        {
            SpawnPassengerAtRandomSpot();
        }

        private void SpawnPassengerAtRandomSpot()
        {
            GeneratePassengerSpots(out PassengerSpot embarkSpot, out PassengerSpot disembarkSpot);

            var passenger = Instantiate(passengerPrefab, embarkSpot.Position, Quaternion.identity)
                .GetComponent<Passenger>();
            passenger.SetDisembarkSpot(disembarkSpot);

            CPassenger = passenger;
        }

        private void SpawnDisembarkSpot()
        {
            Instantiate(disembarkSpotPrefab, CPassenger.DisembarkSpot.Position, Quaternion.identity);
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