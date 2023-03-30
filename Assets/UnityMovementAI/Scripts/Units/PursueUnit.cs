using UnityEngine;

namespace UnityMovementAI
{
    public class PursueUnit : MonoBehaviour
    {
        public MovementAIRigidbody target;

        SteeringBasics steeringBasics;
        Pursue pursue;

        void Start()
        {
            steeringBasics = GetComponent<SteeringBasics>();
            pursue = GetComponent<Pursue>();
            //BugControl
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementAIRigidbody>();
            }
        }

        void FixedUpdate()
        {
            Vector3 accel = pursue.GetSteering(target);

            steeringBasics.Steer(accel);
            steeringBasics.LookWhereYoureGoing();
        }
    }
}