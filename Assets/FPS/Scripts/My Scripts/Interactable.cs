using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace AG3787
{


    public class Interactable : MonoBehaviour
    {
        Outline outline;
        public string message;

        public UnityEvent onInteraction;


        void Start()
        {
            outline = GetComponent<Outline>();
            DisableOutline();
        }
        public void Interact()
        {
            // Will call everything that is set in the inspector
            onInteraction.Invoke();
        }
        public void DisableOutline()
        {
            outline.enabled = false;
        }
        public void EnableOutline()
        {
            outline.enabled = true;
        }

    }
}