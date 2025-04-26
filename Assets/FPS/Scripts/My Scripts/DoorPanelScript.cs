using UnityEngine;
using UnityEngine.Events;


namespace AG3787
{
   
    public class DoorPanelScript : Interactable
    {
        [Header("Door Settings")]
        public GameObject doorObject; // Reference to the door object
        public float openSpeed = 2f;
        public float openHeight = 5;
      

        private Vector3 _closedPosition; // store the doors closed position
        private Vector3 _openPosition;  // store the doors target open position
        private bool _isOpening = false; // flag to start opening the door
       

        public override void Start()
        {
            base.Start();
            if (doorObject != null)
            {
                //save the doors starting (closed) position
                _closedPosition = doorObject.transform.position;
                //calculate the target open position & move up by openHeight
                _openPosition = _closedPosition + Vector3.up * openHeight;
            }
        }

        private void Update()
        {
            //If the door is supposed to be opening
            if (_isOpening && doorObject != null)
            {
                //move the door towards the open position smoothly over time
                doorObject.transform.position = Vector3.MoveTowards
                    (doorObject.transform.position, // current position
                    _openPosition, // Target position
                    openSpeed*Time.deltaTime); // Speed
            }

        }
     
        public void OpenDoor()
        {
            _isOpening = true;
        }
    }
}