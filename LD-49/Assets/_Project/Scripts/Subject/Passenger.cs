using UnityEngine;

namespace Gisha.LD49.Subject
{
    public class Passenger : MonoBehaviour
    {
        public PassengerSpot DisembarkSpot { get; private set; }

        public void SetDisembarkSpot(PassengerSpot spot)
        {
            DisembarkSpot = spot;
        }
    }
}