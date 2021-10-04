using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gisha.LD49.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject creditsMenu;

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
    }
}