using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClouds : MonoBehaviour {
    public float speed = 1f;
	void Update () {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);

    }
}
