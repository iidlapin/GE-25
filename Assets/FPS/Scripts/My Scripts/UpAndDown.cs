using UnityEngine;

namespace AG3787
{
    public class UpAndDown : MonoBehaviour
    {
        [SerializeField] private Transform[] targetEndPoints;

        public float speed = (1f);

        private Transform target;

        private int currentEndPointIndex = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            target = targetEndPoints[0];
        }

        // Update is called once per frame
        void Update()
        {
            var step = speed* Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if(Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                SwapEndPointTarget();
            }
        }

        public void SwapEndPointTarget()
        {
            currentEndPointIndex++;
            currentEndPointIndex%= targetEndPoints.Length;
            target = targetEndPoints[currentEndPointIndex];
        }
    } 
}
