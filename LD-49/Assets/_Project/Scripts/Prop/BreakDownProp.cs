using UnityEngine;

namespace Gisha.LD49.Prop
{
    public class BreakDownProp : MonoBehaviour
    {
        [SerializeField] private Sprite brokenSprite;

        private SpriteRenderer _sr;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        public virtual void BreakDown()
        {
            _sr.sprite = brokenSprite;
            _sr.sortingOrder = 0;
            Destroy(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Vehicle"))
                BreakDown();
        }
    }
}