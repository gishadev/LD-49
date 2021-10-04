using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gisha.LD49.GUI
{
    public class LoseMenu : MonoBehaviour
    {
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