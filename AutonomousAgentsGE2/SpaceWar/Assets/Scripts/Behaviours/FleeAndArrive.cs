using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{

    public class FleeAndArrive : SteeringBehaviour
    {
        TargetingSystem targetingSystem;
        public Vector3 targetPosition = Vector3.zero;
        public float slowingDistance = 15.0f;
        [HideInInspector]

        [Range(0.0f, 1.0f)]
        public float deceleration = 0.9f;

        private void Start()
        {
            targetingSystem = GetComponent<TargetingSystem>();
        }

        private GameObject targetGameObject = null;

        public override Vector3 Calculate()
        {
            Vector3 toTarget = transform.position - targetPosition;
            float distance = toTarget.magnitude;
            if (distance > slowingDistance)
            {
                return Vector3.zero;
            }
            float rampedSpeed = boid.maxSpeed * (distance / slowingDistance * deceleration);
            float clamped = Mathf.Min(rampedSpeed, boid.maxSpeed);
            Vector3 desired = clamped * (toTarget / distance);
            return desired - boid.velocity;
        }

        // Update is called once per frame
        void Update()
        {
            if (targetGameObject != null)
            {
                targetPosition = targetingSystem.FindTargets().transform.position;
            }
            else
            {
                targetPosition = targetingSystem.FindTargets().transform.position;
                //StateMachine stateMachine = GetComponent<StateMachine>();
                //  stateMachine.boidState = StateMachine.BoidState.OFFSETPURSUE;
            }
        }
    }
}