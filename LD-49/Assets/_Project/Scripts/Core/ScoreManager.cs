using TMPro;
using UnityEngine;

namespace Gisha.LD49.Core
{
    public class ScoreManager : MonoBehaviour
    {
        private static ScoreManager Instance { set; get; }

        [SerializeField] private TMP_Text scoreTMPText;

        public static int Score => Instance._scoreCount;
        
        private int _scoreCount;

        private void Awake()
        {
            Instance = this;
        }
        
        public static void AddScore(int count)
        {
            Instance.AddScoreForCount(count);
        }

        private void AddScoreForCount(int count)
        {
            _scoreCount += count;
            scoreTMPText.text = _scoreCount.ToString();
        }
    }
}