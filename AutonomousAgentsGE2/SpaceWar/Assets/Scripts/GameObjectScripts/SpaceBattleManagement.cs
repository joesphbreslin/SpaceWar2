using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behaviours;

    public class SpaceBattleManagement : MonoBehaviour
    {

        public float forwardOffset = 30f;
        public float SideOffset = 15f;
        public string EF_MothershipTag;
        bool unitsDeployed, redDeployed, jetsDeployed, EFGundamDeployed;
        public GameObject ZionUnit, ZionRedUnit, ZionMothership;

        public enum EF_Defend { DOCILE, DEPLOY_JETS, DEPLOY_GUNDAM };
        public enum ZionAttack { WARP, DEPLOY_UNITS, DEPLOY_RED };
        public EF_Defend ef_defend;
        public ZionAttack zionAttack;


        private void Start()
        {
            ef_defend = EF_Defend.DOCILE;
            zionAttack = ZionAttack.WARP;
            unitsDeployed = false;
            redDeployed = false;
            jetsDeployed = false;
            EFGundamDeployed = false;
        }
        void Update()
        {
            switch (ef_defend)
            {
                case EF_Defend.DOCILE:
                    break;
                case EF_Defend.DEPLOY_JETS:
                    if (!jetsDeployed)
                    {
                        DeployJets();
                    }
                    break;
                case EF_Defend.DEPLOY_GUNDAM:
                    if (!EFGundamDeployed)
                    {
                        DeployGundam();
                    }
                    break;
                default:
                    break;
            }
            switch (zionAttack)
            {
                case ZionAttack.WARP:
                    break;
                case ZionAttack.DEPLOY_UNITS:
                    if (!unitsDeployed)
                    {
                  
                    }
                    break;
                case ZionAttack.DEPLOY_RED:
                    if (!redDeployed)
                    {
                     
                    }
                    break;
                default:
                    break;
            }
        }

      

        void DeployJets()
        {

        }

        void DeployGundam()
        {

        }
    }

