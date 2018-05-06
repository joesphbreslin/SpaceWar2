using UnityEngine;
using System.Collections;
using System;

public class ShotAlert : MonoBehaviour {

    public string[] bulletTags = new string[3];
    StateMachine stateMachine;
  
    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == bulletTags[0] || other.tag == bulletTags[1] || other.tag == bulletTags[2])
        {
            StartCoroutine(Attack());           
        }
    }

    IEnumerator Attack()
    {
        stateMachine.gunState = StateMachine.GunState.SHOOTING;
        yield return new WaitForSeconds(5);
    }

}
