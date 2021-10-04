using UnityEngine;

namespace Gisha.LD49.Prop
{
    public class Lamp : BreakDownProp
    {
        [SerializeField] private float fallOffset;

        public override void BreakDown()
        {
            base.BreakDown();

            transform.position += Vector3.up * fallOffset;
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}