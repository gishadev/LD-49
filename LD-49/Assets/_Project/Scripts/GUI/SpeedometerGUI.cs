using Gisha.LD49.Core;
using Gisha.LD49.Taxi;
using TMPro;
using UnityEngine;

namespace Gisha.LD49.GUI
{
    public class SpeedometerGUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _speedometerTMPText;
        [SerializeField] private Color safeColor;
        [SerializeField] private Color dangerColor;

        private TaxiController _controller;

        private void Awake()
        {
            _controller = FindObjectOfType<TaxiController>();
        }

        private void Update()
        {
            _speedometerTMPText.text = _controller.ConvertedSpeed.ToString();
            
            ApplyColor(MineManager.IsSafe);
        }

        private void ApplyColor(bool isSafe)
        {
            if (isSafe)
                _speedometerTMPText.color = safeColor;
            else
                _speedometerTMPText.color = dangerColor;
        }
    }
}
