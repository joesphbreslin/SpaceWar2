
using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    static public bool portalOpened = false;
    public Animator
        anim;
    
    public GameManager gameManager;

    void Start () {
        anim.SetBool("Portal", true);
        StartCoroutine(SetPortalOpen());
	}

    IEnumerator SetPortalOpen()
    {
        yield return new WaitForSeconds(6);
        portalOpened = true;
      

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ClosePortalTrigger")
        {
            anim.SetBool("Portal", false);
            portalOpened = false;
            gameManager.DeployZion();


        }
    }
}
