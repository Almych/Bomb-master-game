using System.Threading.Tasks;
using TMPro;
using UnityEngine;



    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TrafficColors traffic;
        [SerializeField] private TextMeshProUGUI scoreBoard;
        private float totalTime = 0f;
        private bool scoreUpdated = false;

        private void Update()
        {
            totalTime += Time.deltaTime;

            if (traffic.isEnded && !scoreUpdated)
            {
                ScoreCount();
                scoreUpdated = true; 
            }
        }

        private void ScoreCount()
        {
            float score = totalTime * traffic.countPoint;
            scoreBoard.text = score.ToString("f3");
        }
    }


