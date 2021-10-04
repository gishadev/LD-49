using Gisha.Effects.Audio;
using Gisha.Effects.VFX;
using Gisha.LD49.Taxi;
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
        public static float TimeLeft => Instance._delay;
        
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
                OneBeep();
                _delay -= Time.deltaTime;
                if (_delay < 0f)
                    Explode();
            }

            else
            {
                _delay = explodeDelayInSeconds;
                _isOnceBeeped = false;
            }
        }

        private void Explode()
        {
            Debug.Log("<color=red>KABOOM!</color>");
            
            VFXManager.Instance.Emit("Explosion", taxiController.transform.position);
            AudioManager.Instance.PlaySFX("explosion");
            
            taxiController.gameObject.SetActive(false);
            GameManager.ReloadScene();
            
            _isExploded = true;
        }

        private bool _isOnceBeeped = false;

        private void OneBeep()
        {
            if (!_isOnceBeeped)
            {
                AudioManager.Instance.PlaySFX("beep");
                _isOnceBeeped = true;
            }
        }
    }
}