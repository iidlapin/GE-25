using UnityEngine;
using TMPro;

namespace AG3787
{
    public class HUDController : MonoBehaviour
    {
        public static HUDController instance;

        private void Awake()
        {
            instance = this;
        }

        [SerializeField] TMP_Text interactionText;
        private void Start()
        {
           interactionText.gameObject.SetActive(false);
        }
        public void EnableInteractionText(string text, int cost)
        { 
            interactionText.text = text + "\n" + cost + " coins \n (E)"; // Hard coded but we don't care
            interactionText.gameObject.SetActive(true);
        }

        public void DisableInteractionText()
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}