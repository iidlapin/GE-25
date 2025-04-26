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

        public void EnableInteractionText(string text)
        { 
            interactionText.text = text + " (E)"; // Hard coded but we don't care
            interactionText.gameObject.SetActive(true);
        }
        public void DisableInteractionText()
        {
            interactionText.gameObject.SetActive(false);
        }


    }
}