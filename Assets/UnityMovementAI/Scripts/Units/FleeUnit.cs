using UnityEngine;

namespace UnityMovementAI
{
    public class FleeUnit : MonoBehaviour
    {
        public Transform target;

        SteeringBasics steeringBasics;
        Flee flee;

        void Start()
        {
            steeringBasics = GetComponent<SteeringBasics>();
            flee = GetComponent<Flee>();
            //BUG CONTROL
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            }
        }

        void FixedUpdate()
        {
            Vector3 accel = flee.GetSteering(target.position);

            steeringBasics.Steer(accel);
            steeringBasics.LookWhereYoureGoing();
        }
    }
}