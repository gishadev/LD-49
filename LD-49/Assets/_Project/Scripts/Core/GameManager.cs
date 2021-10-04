using Gisha.Effects.Audio;
using UnityEngine;

namespace Gisha.LD49.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject loseMenu;
        private static GameManager Instance { get; set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            AudioManager.Instance.PlaySFX("engine1Start");
        }

        public static void CallLoseMenu()
        {
            Instance.loseMenu.SetActive(true);
        }
    }
}