using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gisha.LD49.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float reloadDelay = 2f;
        private static GameManager Instance { get; set; }

        private void Awake()
        {
            Instance = this;
        }

        public static void ReloadScene()
        {
            Instance.ReloadSceneWithDelay();
        }

        private void ReloadSceneWithDelay()
        {
            StartCoroutine(ReloadSceneCoroutine());
        }
        
        private IEnumerator ReloadSceneCoroutine()
        {
            yield return new WaitForSeconds(reloadDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}