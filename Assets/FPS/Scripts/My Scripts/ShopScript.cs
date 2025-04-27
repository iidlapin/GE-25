using Unity.FPS.Game;
using UnityEngine;

namespace AG3787
{
    
    public class ShopScript : Interactable
    {
        public GameObject player;
        public float HealAmount = 10;
   
        public void BuyHealth()
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth && playerHealth.CanPickup())
            {
                playerHealth.Heal(HealAmount);
               
            }
        }

    }

}