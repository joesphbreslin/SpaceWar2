using UnityEngine;

namespace Behaviours
{
    public class Seek : SteeringBehaviour
    {
        public bool isMothershipEF = false;
        public bool isZionMothership = false;
        GameObject earth, EF_Mothership;
        TargetingSystem targetingSystem;
        private GameObject targetGameObject = null;
        public Vector3 target = Vector3.zero;

        private void Start()
        {
            EF_Mothership = GameObject.FindGameObjectWithTag("EF_Mothership");
            earth = GameObject.FindGameObjectWithTag("Earth");
            targetingSystem = GetComponent<TargetingSystem>();
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
            Vector3 desired = target - transform.position;
            desired.Normalize();
            desired *= boid.maxSpeed;
            return desired - boid.velocity;
        }

        void Update()
        {
            if (!isMothershipEF && !isZionMothership) {
                if (targetGameObject != null)
                {
                    target = targetingSystem.FindTargets().transform.position;
                }
                else
                {
                    target = targetingSystem.FindTargets().transform.position;
                    //StateMachine stateMachine = GetComponent<StateMachine>();
                    // stateMachine.boidState = StateMachine.BoidState.OFFSETPURSUE;
                }
            }
            else if(isMothershipEF)
            {
                target = earth.transform.position;
            }else if (isZionMothership)
            {
                target = EF_Mothership.transform.position;
            }
        }
    }
}