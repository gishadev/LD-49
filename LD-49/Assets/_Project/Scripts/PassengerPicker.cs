using UnityEngine;

namespace Gisha.LD49
{
    public class PassengerPicker : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Passenger"))
            {
                Debug.Log("<color=yellow>You've picked a passenger!</color>");
                Destroy(other.gameObject);
            }
        }
    }
}