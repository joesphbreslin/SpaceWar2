using UnityEngine;
public class Shoot : MonoBehaviour
{
    //Attach to Gun Object
    AudioSource AS;
    private float range = 130f;                                      //Shot Range
    public GameObject bulletPrefab;                                 //Make sure rigidbody component is attached to bullet
    private float fireRate;                                         //How often Bullets are fired
    public float forceMult;                                         //Scaler
    public string target1, target2, target3;
    private GameObject target;                                      //Gun Target
    private float timer;                                            //FireRate Timer variable;

    RaycastHit hit;                                                 
    TargetingSystem targetingSystem;
    StateMachine stateMachine;

    private void Start()
    {
        fireRate = UnityEngine.Random.Range(1f, 1.8f);
        AS = GetComponent<AudioSource>();
        timer = fireRate;
        targetingSystem = GetComponentInParent<TargetingSystem>();
        target = targetingSystem.FindTargets().gameObject;
        stateMachine = GetComponentInParent<StateMachine>();
    }
    void FixedUpdate () {

        if (stateMachine.gunState == StateMachine.GunState.SHOOTING)
        {
            target = targetingSystem.FindTargets().gameObject;
            if (target != null)
            {
                
                transform.LookAt(target.transform);
            }
              

                if (Physics.Raycast(transform.position, transform.forward, out hit, range))
                {
                    Debug.DrawRay(transform.position, transform.forward * range, Color.magenta);
                    if (hit.transform.gameObject.tag == target1 || hit.transform.gameObject.tag == target2 || hit.transform.gameObject.tag == target3)
                    {
                        //Debug.Log("Shoot");
                        Shot();
                    }
                }
            }
      
	}

    void Shot()
    {
        if (timer <= 0)
        {
            GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            Rigidbody rb = go.GetComponent<Rigidbody>();
            AS.Play();
            rb.AddForce(transform.forward * forceMult ,ForceMode.Impulse);
           // Debug.Log("Fired");
            timer = fireRate;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

}
