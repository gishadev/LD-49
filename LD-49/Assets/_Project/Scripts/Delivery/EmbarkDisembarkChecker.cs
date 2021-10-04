using System;
using Gisha.Effects.Audio;
using UnityEngine;

namespace Gisha.LD49.Delivery
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
                AudioManager.Instance.PlaySFX("pickPassenger");
                
                Destroy(other.gameObject);
                PassengerEmbarked?.Invoke();
            }

            else if (other.CompareTag("Destination"))
            {
                Debug.Log("<color=yellow>You've disembarked a passenger!</color>");
                AudioManager.Instance.PlaySFX("pickPassenger");
                
                Destroy(other.gameObject);
                PassengerDisembarked?.Invoke();
            }
        }
    }
}