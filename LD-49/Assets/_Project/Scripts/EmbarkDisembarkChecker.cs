using System;
using UnityEngine;

namespace Gisha.LD49
{
    public class EmbarkDisembarkChecker : MonoBehaviour
    {
        public static Action PassengerEmbarked;
        public static Action PassengerDisembarked;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Passenger"))
            {
                Debug.Log("<color=yellow>You've picked a passenger!</color>");
                Destroy(other.gameObject);

                PassengerEmbarked?.Invoke();
            }

            else if (other.CompareTag("Disembark"))
            {
                Debug.Log("<color=yellow>You've disembarked a passenger!</color>");
                Destroy(other.gameObject);

                PassengerDisembarked?.Invoke();
            }
        }
    }
}