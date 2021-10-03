using System;
using Gisha.LD49.Core;
using TMPro;
using UnityEngine;

namespace Gisha.LD49.GUI
{
    public class SpeedometerGUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _speedometerTMPText;

        private TaxiController _controller;

        private void Awake()
        {
            _controller = FindObjectOfType<TaxiController>();
        }

        private void Update()
        {
            _speedometerTMPText.text = _controller.ConvertedSpeed.ToString();
        }
    }
}
