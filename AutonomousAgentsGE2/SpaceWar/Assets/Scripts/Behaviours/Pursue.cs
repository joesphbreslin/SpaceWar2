using UnityEngine;

namespace Behaviours
{
    public class Pursue : SteeringBehaviour
    {
        TargetingSystem targetingSystem;

        Boid targetBoid;
        GameObject target;
        Vector3 targetPos;

        public void OnDrawGizmos()
        {
            if (isActiveAndEnabled && Application.isPlaying)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, targetPos);
            }
        }
 
        public void Update()
        {
            targetingSystem = GetComponent<TargetingSystem>();
            target = targetingSystem.FindTargets();

        

            targetBoid = target.GetComponent<Boid>();
        }

        public override Vector3 Calculate()
        {
            //  targetingSystem = GetComponent<TargetingSystem>();
            //target = targetingSystem.FindTargets().GetComponent<Boid>();
          
            float dist = Vector3.Distance(target.transform.position, transform.position);
            float time = dist / boid.maxSpeed;
            targetPos = target.transform.position + (time * targetBoid.velocity);
            Vector3 desired = targetPos - transform.position;
            desired.Normalize();
            desired *= boid.maxSpeed;
            return desired - boid.velocity;

        }
    }
}