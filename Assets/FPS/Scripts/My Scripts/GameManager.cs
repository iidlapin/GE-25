using UnityEngine;
namespace AG3787
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SpawnerManager spawnerManager; // for spawning enemies or coins
        [SerializeField] private UiController uiController;
        public int score { get; private set; } // Current score
        public int playerCoins { get; private set; } //Coins ( used for bying)

        private void Start()
        {
            spawnerManager.StartSpawning();
        }
    
        // Method to increment score (this is separate from coins)
        public void IncrementScore()
        {
            score++;
            Debug.Log("Score: " + score); // To see score in the console
        }
        // Method to add coins when the player collects a coin
        public void AddCoins(int amount)
        {
            playerCoins += amount;
            Debug.Log("Coins: " + playerCoins);  // To see coins in the console
        }
        public bool HasEnoughCoins(int Cost)
        {

            return playerCoins >= Cost; //Check if player has enough coins
        }
        public void SpendCoins(int cost)
        {

            playerCoins -= cost;
            Debug.Log("Coins spent: " + cost);  // Output to console for debugging

            uiController.UpdateScore();


        }
    }
}