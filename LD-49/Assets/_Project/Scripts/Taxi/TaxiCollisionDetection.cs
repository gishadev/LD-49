using Gisha.Effects.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gisha.LD49.Taxi
{
    public class TaxiCollisionDetection : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            int rNum = Random.Range(0, 2);
            switch (rNum)
            {
                case 0:
                    AudioManager.Instance.PlaySFX("hit2");
                    break;
                case 1:
                    AudioManager.Instance.PlaySFX("hit3");
                    break;
            }
        }
    }
}