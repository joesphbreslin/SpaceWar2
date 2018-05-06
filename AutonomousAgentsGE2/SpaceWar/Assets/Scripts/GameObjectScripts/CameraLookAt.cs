using UnityEngine;

public class CameraLookAt : MonoBehaviour {
    public Transform center;

    void Update() {
        transform.LookAt(center);
        }
    

}
