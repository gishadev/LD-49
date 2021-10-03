using System.Collections;
using Gisha.Effects.VFX;
using UnityEngine;

namespace Gisha.LD49.Core
{
    public class MineManager : MonoBehaviour
    {
        private static MineManager Instance { get; set; }

        [SerializeField] private TaxiController taxiController;
        [SerializeField] private float minSafeSpeed;
        [SerializeField] private float explodeDelayInSeconds;
        public static bool IsSafe => Instance.TaxiSpeed > Instance.minSafeSpeed;

        private float TaxiSpeed => taxiController.ConvertedSpeed;

        private bool _isExploded = false;
        private float _delay;

        private void Awake()
        {
            Instance = this;
            _delay = explodeDelayInSeconds;
        }

        private void Update()
        {
            if (_isExploded)
                return;

            if (!IsSafe)
            {
                _delay -= Time.deltaTime;
                if (_delay < 0f)
                    Explode();
            }

            else
                _delay = explodeDelayInSeconds;
        }

        private void Explode()
        {
            VFXManager.Instance.Emit("Explosion", taxiController.transform.position);
            taxiController.gameObject.SetActive(false);
            Debug.Log("<color=red>KABOOM!</color>");
            GameManager.ReloadScene();
            _isExploded = true;
        }
    }
}