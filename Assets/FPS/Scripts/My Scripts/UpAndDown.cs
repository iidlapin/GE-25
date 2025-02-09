using UnityEngine;

namespace AG3787
{
    public class UpAndDown : MonoBehaviour
    {
        //Array to hold the target end points the object will move between
        [SerializeField] private Transform[] targetEndPoints;
        
        //Setting the speed that the object will move between the targets
        public float Speed = 1f;

        //Current target the object is moving towards
        private Transform target;

        // Index to track which target in the array is the current target
        private int currentEndPointIndex = 0;

        void Start()
        {
            //Initializing the target to the first target endpoint
            target = targetEndPoints[0];
        }

        void Update()
        {
            //Calculating ghow much to move the object based on speed and current time
            var step = Speed * Time.deltaTime;

            //Moving the object towards target position each frame
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            //iF the object is very close to the target, swwap the target
            if(Vector3.Distance(transform.position, target.position) < 0.001f)
                SwapEndPointTarget();
        }

        //Method to change the target point to the next target point in the array
        private void SwapEndPointTarget()
        {
            //Increment index to move to next target
            currentEndPointIndex++;
            //Use modulo to loop back to the first index when array lenght runs out
            currentEndPointIndex %= targetEndPoints.Length;
            //Set new target to the next end point in the array
            target = targetEndPoints[currentEndPointIndex];
        }
    } 
}
