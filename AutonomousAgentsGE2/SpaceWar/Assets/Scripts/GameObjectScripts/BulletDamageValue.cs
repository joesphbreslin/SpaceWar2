using UnityEngine;
public class BulletDamageValue : MonoBehaviour {
    public int damage;
    public float decay;

    private void Awake()
    {
        Destroy(gameObject, decay);
    }
}
