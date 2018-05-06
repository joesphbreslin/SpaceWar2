using UnityEngine;
using System.Collections;

public class MeshCombine : MonoBehaviour {
    Transform container;
    void Start() {
        container = GetComponentInParent<Transform>();
        MeshFilter[] meshFilter = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilter.Length];
        int i = 0;
        while(i< meshFilter.Length){
            combine[i].mesh = meshFilter[i].sharedMesh;
            combine[i].transform = meshFilter[i].transform.localToWorldMatrix;
            meshFilter[i].gameObject.SetActive(false);
            i++;
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
        transform.position = container.position;
    }
}
