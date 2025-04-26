using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
namespace AG3787
{
    public class CoinScript : MonoBehaviour
    {
        public UnityEvent coinCollect; // event for collecting the coin
        public int coinsToAdd = 1; 
        private void Start()
        {
            // Adding the listener to the coinCollect event using a wrapper method
            coinCollect.AddListener(AddCoinsToPlayer);
            coinCollect.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UiController>().UpdateScore);  // Update UI if needed
        }

        private void AddCoinsToPlayer()
        {
            // Call the AddCoins method with the specific amount
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().AddCoins(coinsToAdd);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Player"))  // When the player collides with the coin
            {
                coinCollect.Invoke(); // Call the coinCollect events
                Destroy(gameObject); // Destroy the coin after collecting
            }
        }
    }
}