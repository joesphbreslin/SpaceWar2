using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    public class OffsetPursue : SteeringBehaviour
    {
        public Boid leader;
        private Vector3 offset;
        Vector3 worldTarget;

        private void Start()
        {
            offset = transform.position - leader.transform.position;
            offset = Quaternion.Inverse(leader.transform.rotation) * offset;
        }

        public override Vector3 Calculate()
        {
            worldTarget = leader.transform.TransformPoint(offset);
            float dist = Vector3.Distance(worldTarget, transform.position);
            float time = dist / boid.maxSpeed;

            Vector3 targetPos = worldTarget + (leader.velocity * time);
            return ArriveForce(targetPos, 10);
        }

        Vector3 ArriveForce(Vector3 targetPosition, float slowingDistance = 15.0f, float deceleration = 0.9f)
        {
            Vector3 toTarget = targetPosition - transform.position;
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
    }
}