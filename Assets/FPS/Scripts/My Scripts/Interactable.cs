using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine.Rendering;

namespace AG3787
{

    public class Interactable : MonoBehaviour
    {
        Outline outline;
       
        public int Cost = 10;
        public UnityEvent onInteraction;

        public string Message;


        public virtual void Start()
        {
            outline = GetComponent<Outline>();
            DisableOutline();
        }
        public void ShowMessage()
        {
            HUDController.instance.EnableInteractionText(Message,Cost);

        }
        public void HideMessage() 
        {
            HUDController.instance.DisableInteractionText();
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