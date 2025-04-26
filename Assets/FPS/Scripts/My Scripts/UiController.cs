using UnityEngine;
using TMPro;

namespace AG3787
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI PlayerScore;
        GameManager gameManager;

        private void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
        public void UpdateScore()
        {
            PlayerScore.text = "Coins: " + gameManager.score.ToString();
        }
    }

}
