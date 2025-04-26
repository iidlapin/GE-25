using System;
using UnityEngine;

namespace AG3787 {
    public class PlayerInteraction : MonoBehaviour
    {
        public float PlayerReach = 3f;
        Interactable currentInteractable;

        void Update()
        {
            CheckInteraction();
            if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }

        void CheckInteraction()
        {
            RaycastHit hit;
            //Creates a raycast from the center of the camera forward
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            //Checks if raycast collides with anything in the players reach
            if (Physics.Raycast(ray, out hit, PlayerReach))
            {
                if (hit.collider.tag == "Interactable")  // if looking at an interactable object
                {
                    Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                    // If there is many interactable objects near each other, check if the currentInteractable is not the newInteractable
                    if (currentInteractable && newInteractable != currentInteractable)
                    {
                        currentInteractable.DisableOutline();
                    }
                    if (newInteractable.enabled)
                    {
                        SetNewCurrentInteractable(newInteractable);
                    }
                    else // if new interactable is not enabled
                    {
                        DisableCurrentInteractable();
                    }
                }
                else // if not interactable
                {
                    DisableCurrentInteractable();
                }
            }
            else // if nothing in reach
            {
                DisableCurrentInteractable();
            }
        }

        void SetNewCurrentInteractable(Interactable newInteractable)
        {
            currentInteractable = newInteractable;
            currentInteractable.EnableOutline();
            HUDController.instance.EnableInteractionText(currentInteractable.message);
        }

        void DisableCurrentInteractable()
        {
            HUDController.instance.DisableInteractionText();
            if (currentInteractable)
            {
                currentInteractable.DisableOutline();
                currentInteractable = null;
            }
        }
    }
}