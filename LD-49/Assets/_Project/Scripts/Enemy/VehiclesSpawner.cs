using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gisha.LD49.Enemy
{
    public class VehiclesSpawner : MonoBehaviour
    {
        [SerializeField] private int vehiclesCount = 3;
        [SerializeField] private GameObject vehiclePrefab;
        
        private List<Transform> _vehicleSpots = new List<Transform>();

        private void Start()
        {
            _vehicleSpots = GameObject.FindGameObjectsWithTag("VehicleSpot")
                .Select(x => x.transform)
                .ToList();

            SpawnVehicles();
        }

        private void SpawnVehicles()
        {
            for (int i = 0; i < vehiclesCount; i++)
            {
                var randomSpot = GetRandomSpot();
                var vehicle = Instantiate(vehiclePrefab, randomSpot.position, randomSpot.rotation);
            }
        }

        private Transform GetRandomSpot()
        {
            var spot = _vehicleSpots[Random.Range(0, _vehicleSpots.Count)];
            _vehicleSpots.Remove(spot);

            return spot;
        }
    }
}