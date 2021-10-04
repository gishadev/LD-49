using UnityEngine;

namespace Gisha.LD49.Delivery
{
    public class Passenger : MonoBehaviour
    {
        public PassengerSpot DestinationSpot { get; private set; }

        public void SetDisembarkSpot(PassengerSpot spot)
        {
            DestinationSpot = spot;
        }
    }
}