using UnityEngine;

namespace Gisha.LD49.Core
{
    public class SpritesRandomizer : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites;

        private void Start()
        {
            if (sprites == null || sprites.Length == 0)
                return;

            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}