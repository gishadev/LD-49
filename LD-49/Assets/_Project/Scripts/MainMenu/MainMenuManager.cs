using System;
using Gisha.Effects.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gisha.LD49.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject creditsMenu;
        [Space] [SerializeField] private Image sfxImage;
        [SerializeField] private Image musicImage;
        [SerializeField] private Sprite soundsOn, soundsOff;

        private void Start()
        {
            sfxImage.sprite = AudioManager.Instance.IsSfxMuted ? soundsOff : soundsOn;
            musicImage.sprite = AudioManager.Instance.IsMusicMuted ? soundsOff : soundsOn;
        }

        public void OnClick_Play()
        {
            SceneManager.LoadScene(1);
        }

        public void OnClick_Credits()
        {
            creditsMenu.SetActive(true);
        }

        public void OnClick_ReturnToMenu()
        {
            creditsMenu.SetActive(false);
        }

        public void OnClick_SFX()
        {
            if (!AudioManager.Instance.IsSfxMuted)
            {
                AudioManager.Instance.SetSFXVolume(0f);
                sfxImage.sprite = soundsOff;
            }
            else
            {
                AudioManager.Instance.SetSFXVolume(0.5f);
                sfxImage.sprite = soundsOn;
            }
        }

        public void OnClick_Music()
        {
            if (!AudioManager.Instance.IsMusicMuted)
            {
                AudioManager.Instance.SetMusicVolume(0f);
                musicImage.sprite = soundsOff;
            }
            else
            {
                AudioManager.Instance.SetMusicVolume(0.1f);
                musicImage.sprite = soundsOn;
            }
        }
    }
}