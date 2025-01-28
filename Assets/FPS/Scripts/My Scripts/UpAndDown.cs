using UnityEngine;

namespace AG3787
{
    public class UpAndDown : MonoBehaviour
    {
        [SerializeField] private Transform[] targetEndPoints;

        public float Speed = 1f;

        private Transform target;

        private int currentEndPointIndex = 0;

        void Start()
        {
            target = targetEndPoints[0];
        }

        void Update()
        {
            var step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if(Vector3.Distance(transform.position, target.position) < 0.001f)
                SwapEndPointTarget();
        }

        private void SwapEndPointTarget()
        {
            currentEndPointIndex++;
            currentEndPointIndex %= targetEndPoints.Length;
            target = targetEndPoints[currentEndPointIndex];
        }
    } 
}
