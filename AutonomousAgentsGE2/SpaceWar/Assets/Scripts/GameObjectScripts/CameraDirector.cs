using UnityEngine;
using System.Collections;

public class CameraDirector : MonoBehaviour {

    bool firstChange;
    public Transform firstCam;
    GameObject[] CameraLoc;
    public Camera cam;
    public Transform defaultTrans;
    int randomValue;

    private void Start()
    {
        firstChange = false;
        StartCoroutine(ChangeCamera());
    }

    

    private void LateUpdate()
    {
        if (!firstChange)
        {
            cam.transform.position = firstCam.transform.position;
            cam.transform.rotation = firstCam.transform.rotation;
        }
        else
        {
            if (CameraLoc[randomValue] != null)
            {
                cam.transform.position = CameraLoc[randomValue].transform.position;
                cam.transform.rotation = CameraLoc[randomValue].transform.rotation;
            }
            else
            {
                cam.transform.position = defaultTrans.transform.position;
                cam.transform.rotation = defaultTrans.transform.rotation;
            }
        }
    }

    IEnumerator ChangeCamera()
    {
        CameraLoc = GameObject.FindGameObjectsWithTag("Cam_0");

        randomValue = Random.Range(0, CameraLoc.Length);
        if (!firstChange)
        {
            cam.transform.position = firstCam.transform.position;
            cam.transform.rotation = firstCam.transform.rotation;
        }
        else
        {
            if (CameraLoc[randomValue] != null)
            {
                cam.transform.position = CameraLoc[randomValue].transform.position;
                cam.transform.rotation = CameraLoc[randomValue].transform.rotation;
            }
            else
            {
                cam.transform.position = defaultTrans.transform.position;
                cam.transform.rotation = defaultTrans.transform.rotation;
            }
        }
        yield return new WaitForSeconds(Random.Range(2, 5));
        firstChange = true;
        StartCoroutine(ChangeCamera());

    }
  
}
