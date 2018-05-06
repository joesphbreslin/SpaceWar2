using UnityEngine;
namespace Behaviours
{
    public class Arrive : SteeringBehaviour
    {
        public Vector3 target = Vector3.zero;
        public float slowingDistance = 15.0f;
        [HideInInspector]

        [Range(0.0f, 1.0f)]
        public float deceleration = 0.9f;

        private GameObject targetGameObject = null;

        TargetingSystem targetingSystem;

        private void Start()
        {
            targetingSystem = GetComponent<TargetingSystem>();
            targetGameObject = targetingSystem.FindTargets();
        }

        public override Vector3 Calculate()
        {

            Vector3 toTarget = target - transform.position;
            float distance = toTarget.magnitude;
            if (distance == 0f)
            {
                return Vector3.zero;
            }
            float rampedSpeed = boid.maxSpeed * (distance / slowingDistance * deceleration);
            float clamped = Mathf.Min(rampedSpeed, boid.maxSpeed);
            Vector3 desired = clamped * (toTarget / distance);
            return desired - boid.velocity;
        }

        void Update()
        {
            if (targetGameObject != null)
            {
                target = targetingSystem.FindTargets().transform.position;
            }
            else
            {
                target = targetingSystem.FindTargets().transform.position;
            }
        }
    }
}
