using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderZionMotherShip : MonoBehaviour {
    Renderer[] renderers;
    public GameObject[] particleSystems;

    // Use this for initialization
    void Start () {
        renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
          
        }
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(Portal.portalOpened == true)
        {
            for (int i = 0; i < particleSystems.Length; i++)
            {
                particleSystems[i].SetActive(true);
            }
            foreach (Renderer r in renderers)
            {
                r.enabled = true;
             
                //Portal.portalOpened = false;
                
            }
        }
	}
}
