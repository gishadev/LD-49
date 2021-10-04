using Gisha.Effects.Audio;
using Gisha.Effects.VFX;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gisha.LD49.Core
{
    public class DynamicCollisionDetection : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D coll)
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

            VFXManager.Instance.Emit("Hit", coll.GetContact(0).point);
        }
    }
}