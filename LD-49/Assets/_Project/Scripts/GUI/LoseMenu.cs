using Gisha.LD49.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gisha.LD49.GUI
{
    public class LoseMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreTMPText;

        private void OnEnable()
        {
            scoreTMPText.text = ScoreManager.Score.ToString();
        }

        public void OnClick_Restart()
        {
            SceneManager.LoadScene(1);
        }

        public void OnClick_ReturnToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}