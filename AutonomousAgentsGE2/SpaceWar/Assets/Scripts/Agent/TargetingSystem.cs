using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public float dogFightRange = 1f;
    public bool dogFight;

    public struct Target{

        public GameObject gameObject;
        public GameObject target;

        public float Distance()
        {       
        float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
        return distance;
        }      
    }

    public List<Target> targetList; 
    public string[] targetTags = new string[3];

    void Start()
    { 
        FindTargets();
    }
    public GameObject FindTargets()
    {
     
            targetList = new List<Target>();

            GameObject[] temp = GameObject.FindGameObjectsWithTag(targetTags[0]);
            Target[] targets = new Target[temp.Length];

            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].target = temp[i];
                targets[i].gameObject = gameObject;
                if (targets[i].target != null)
                {
                    targetList.Add(targets[i]);
                }
            }

            Target Secondary_0;
            Secondary_0.target = GameObject.FindGameObjectWithTag(targetTags[1]);
            Secondary_0.gameObject = gameObject;
            if (Secondary_0.target != null)
            {
                targetList.Add(Secondary_0);
            }

            Target Secondary_1;
            Secondary_1.target = GameObject.FindGameObjectWithTag(targetTags[2]);
            Secondary_1.gameObject = gameObject;
            if (Secondary_1.target != null)
            {
                targetList.Add(Secondary_1);
            }

            if (targetList.Count() != 0)
            {

                float min = targetList[0].Distance();
                int minIndex = 0;

                for (int i = 1; i < targetList.Count(); i++)
                {
                    if (targetList[i].Distance() < min)
                    {
                        min = targetList[i].Distance();
                        minIndex = i;
                        if (min < dogFightRange)
                        {
                            dogFight = false;
                        }
                        else
                        {
                            dogFight = true;
                        }
                    }
                }
                return targetList[minIndex].target;
            }
            else
            {
                return this.gameObject;
            }
        
        
    }

}


