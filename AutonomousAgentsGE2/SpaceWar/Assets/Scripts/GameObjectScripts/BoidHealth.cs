using UnityEngine;

public class BoidHealth : MonoBehaviour {

    public string boidName;
    public int health = 100;
    public string[] bulletTags;
    public string[] enemyTags;
    TargetingSystem targetingSystem;
    public GameObject explosionParticleObj;
    public bool isEF = false;
    GameObject dialogueObj;
    DialogueSystem dialogue;

    private void Start()
    {
        dialogueObj = GameObject.FindGameObjectWithTag("Dialogue");
        dialogue = dialogueObj.GetComponent<DialogueSystem>();
      //  print(dialogue.gameObject.name);
        targetingSystem = GetComponent<TargetingSystem>();
      //  text.text = boidName + " health: " + health.ToString();
    }
     void Update()
    {
        if(health <= 0)
        {
            DequeueAndDestroy();
        }
    }
    public void DequeueAndDestroy()
    {

        GameObject explosion = Instantiate(explosionParticleObj,this.transform) as GameObject;
        explosion.transform.SetParent(null);
        if (isEF)
        {           
            GameManager._EFDeathCount --;
            //Debug.Log("BoidHealthBreakPoint1");
            dialogue.ZionCelebrate(GameManager._EFDeathCount);
           // Debug.Log("BoidHealthBreakPoint2");
        }
        else
        {
            GameManager._ZionDeathCount --;
          //  Debug.Log("BoidHealthBreakPoint1");
            dialogue.EFCelebrate(GameManager._ZionDeathCount);
            //Debug.Log("BoidHealthBreakPoint2");

        }
       // targetingSystem.targetList.Remove(this.gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == enemyTags[0]|| collision.gameObject.tag == enemyTags[1] || collision.gameObject.tag == enemyTags[2])
        {
            health -= 50;
            if (health <= 0)
            {
                DequeueAndDestroy();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < bulletTags.Length; i++)
        {
            if (other.tag == bulletTags[i])
            {
                int dam = other.gameObject.GetComponent<BulletDamageValue>().damage;
                health -= dam;
              
                Destroy(other.gameObject);
                if(health <= 0)
                {
                    DequeueAndDestroy();
                }
            }
        }
    }
}
