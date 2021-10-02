using System;
using UnityEngine;

namespace Gisha.LD49
{
    public class PassengerPicker : MonoBehaviour
    {
        public static Action PassengerPicked; 
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Passenger"))
            {
                Debug.Log("<color=yellow>You've picked a passenger!</color>");
                Destroy(other.gameObject);
                
                PassengerPicked?.Invoke();
            }
        }
    }
}