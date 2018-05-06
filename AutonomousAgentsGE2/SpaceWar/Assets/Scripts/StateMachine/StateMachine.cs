using UnityEngine;
using Behaviours;

    public class StateMachine : MonoBehaviour
    {
        TargetingSystem targetingSystem;
        public enum GunState { SHOOTING, NOTSHOOTING};
        public enum BoidState { PURSUE, SEEK, ARRIVE, FLEE, FLEEANDARRIVE, OFFSETPURSUE };
        [Header("Current State")]
        public BoidState boidState;
        [Header("Assigned BoidStates while SHOOTING and in Fighting Range")]
        public BoidState fight;
        [Header("Assigned BoidStates while SHOOTING and in Retreating Range")]
        public BoidState retreat;
        [Header("Assigned BoidStates while NOTSHOOTING")]
        public BoidState defending;    
        [Header("GunState")]
        public GunState gunState;
        Pursue pursue; Arrive arrive; Seek seek; Flee flee; FleeAndArrive fleeAndArrive; OffsetPursue offsetPursue;
        
        private void Start()
        {
        targetingSystem = GetComponent<TargetingSystem>();
            pursue = GetComponent<Pursue>();
            arrive = GetComponent<Arrive>();
            seek = GetComponent<Seek>();
            flee = GetComponent<Flee>();
            fleeAndArrive = GetComponent<FleeAndArrive>();
            offsetPursue = GetComponent<OffsetPursue>();
        }

        void FiniteStateMachine()
        {
      
     
            switch (boidState)
            {
                case BoidState.PURSUE:
                    PursueLogic();
                    break;
                case BoidState.SEEK:
                    SeekLogic();
                    break;
                case BoidState.ARRIVE:
                    ArriveLogic();
                    break;
                case BoidState.FLEE:
                    FleeLogic();
                    break;
                case BoidState.FLEEANDARRIVE:
                    FleeAndArriveLogic();
                    break;
                case BoidState.OFFSETPURSUE:
                    OffsetPursueLogic();
                    break;
                default:
                    break;
            }

            switch (gunState)
            {
            case GunState.SHOOTING:
                if (targetingSystem.dogFight)
                {
                    boidState = fight;
                }
                else
                {
                    boidState = retreat;
                }
                break;
            case GunState.NOTSHOOTING:
                boidState = defending;
                break;
            default:
                //No Fire
                break;

            }
        }

        #region SwitchFunctions

        void PursueLogic()
        {
            pursue.enabled = true;
            arrive.enabled = false;
            seek.enabled = false;
            flee.enabled = false;
            fleeAndArrive.enabled = false;
            offsetPursue.enabled = false;
        }
        void ArriveLogic()
        {
            pursue.enabled = false;
            arrive.enabled = true;
            seek.enabled = false;
            flee.enabled = false;
            fleeAndArrive.enabled = false;
            offsetPursue.enabled = false;
        }
        void SeekLogic()
        {
            pursue.enabled = false;
            arrive.enabled = false;
            seek.enabled = true;
            flee.enabled = false;
            fleeAndArrive.enabled = false;
            offsetPursue.enabled = false;
        }
        void FleeLogic()
        {
            pursue.enabled = false;
            arrive.enabled = false;
            seek.enabled = false;
            flee.enabled = true;
            fleeAndArrive.enabled = false;
            offsetPursue.enabled = false;
        }
        void FleeAndArriveLogic()
        {
            pursue.enabled = false;
            arrive.enabled = false;
            seek.enabled = false;
            flee.enabled = false;
            fleeAndArrive.enabled = true;
            offsetPursue.enabled = false;
        }
        void OffsetPursueLogic()
        {
            pursue.enabled = false;
            arrive.enabled = false;
            seek.enabled = false;
            flee.enabled = false;
            fleeAndArrive.enabled = false;
            offsetPursue.enabled = true;
        }

        #endregion

        // Update is called once per frame
        void Update()
        {
            FiniteStateMachine();
        }
    }

