using UnityEngine;
using TMPro;

namespace AG3787
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI PlayerScore;
        [SerializeField] TextMeshProUGUI CoinsAmount;
        GameManager gameManager;

        private void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    
        }
        public void UpdateScore()
        {
            PlayerScore.text = "Score: " + gameManager.score.ToString();
            CoinsAmount.text = "Coins: " + gameManager.playerCoins.ToString();
        }
    }

}
