using Gisha.LD49.Core;
using Gisha.LD49.Taxi;
using TMPro;
using UnityEngine;

namespace Gisha.LD49.GUI
{
    public class BombGUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text speedometerTMPText;
        [SerializeField] private TMP_Text timeLeftTMPText;
        [Space] [SerializeField] private Color safeColor;
        [SerializeField] private Color dangerColor;
        [Space] [SerializeField] private Animator bombAnimator;


        private TaxiController _controller;

        private void Awake()
        {
            _controller = FindObjectOfType<TaxiController>();
        }

        private void Update()
        {
            speedometerTMPText.text = _controller.ConvertedSpeed.ToString();

            bool isSafe = MineManager.IsSafe;
            bombAnimator.SetBool("IsStable", isSafe);
            if (!isSafe)
            {
                ShowTimer();
            }
            else
                timeLeftTMPText.text = string.Empty;

            ApplyColor(isSafe);
        }

        private void ApplyColor(bool isSafe)
        {
            if (isSafe)
                speedometerTMPText.color = safeColor;
            else
                speedometerTMPText.color = dangerColor;
        }

        private void ShowTimer()
        {
            timeLeftTMPText.text = MineManager.TimeLeft.ToString("F1");
        }
    }
}