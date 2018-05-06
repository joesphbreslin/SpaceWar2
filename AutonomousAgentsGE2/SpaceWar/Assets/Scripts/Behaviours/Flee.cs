using UnityEngine;
namespace Behaviours
{
    public class Flee : SteeringBehaviour
    {
        TargetingSystem targetingSystem;
   
        private GameObject targetGameObject = null;
        public Vector3 target = Vector3.zero;

        private void Start()
        {
            targetingSystem = GetComponent<TargetingSystem>();
            targetGameObject = targetingSystem.FindTargets();
        }

        public void OnDrawGizmos()
        {
            if (isActiveAndEnabled && Application.isPlaying)
            {
                Gizmos.color = Color.cyan;
                if (targetGameObject != null)
                {
                    target = targetGameObject.transform.position;
                }
                Gizmos.DrawLine(transform.position, target);
            }
        }

        public override Vector3 Calculate()
        {
            Vector3 desired = transform.position - target;
            desired.Normalize();
            desired *= boid.maxSpeed;
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
                // StateMachine stateMachine = GetComponent<StateMachine>();
                //stateMachine.boidState = StateMachine.BoidState.OFFSETPURSUE;
            }

        }
    }
}