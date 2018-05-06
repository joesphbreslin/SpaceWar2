using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System;


public class GameManager : MonoBehaviour {

    int sceneIndex = 0;
    static public int _EFDeathCount;
    static public int _ZionDeathCount;
    static public string _victor = "";
    GameObject[] zionGundam;
    GameObject[] zionBoss;
    GameObject[] EF_Fighters;
    GameObject[] EF_Gundam;
    GameObject[] cameras;
    List<Boid> boids = new List<Boid>();
    public GameObject Fade;
    float timer = 20;
    bool changeScene = false;

    private void Start()
    {
        zionGundam = GameObject.FindGameObjectsWithTag("Zion_Gundam");
        zionBoss = GameObject.FindGameObjectsWithTag("Zion_BossGundam");
        EF_Fighters = GameObject.FindGameObjectsWithTag("EF_Fighter");
        EF_Gundam = GameObject.FindGameObjectsWithTag("EF_Gundam");
        _EFDeathCount = EF_Fighters.Length + EF_Gundam.Length;
        _ZionDeathCount = zionGundam.Length + zionBoss.Length;
    }

    public void DeployZion()
    {

            zionGundam = GameObject.FindGameObjectsWithTag("Zion_Gundam");
            zionBoss = GameObject.FindGameObjectsWithTag("Zion_BossGundam");
            EF_Fighters = GameObject.FindGameObjectsWithTag("EF_Fighter");
            EF_Gundam = GameObject.FindGameObjectsWithTag("EF_Gundam");

            cameras = GameObject.FindGameObjectsWithTag("Cam_1");
            _EFDeathCount = EF_Fighters.Length + EF_Gundam.Length;
            _ZionDeathCount = zionGundam.Length + zionBoss.Length;

            for (int i = 0; i < zionGundam.Length; i++)
            {
                boids.Add(zionGundam[i].GetComponent<Boid>());
            }

            for (int i = 0; i < zionBoss.Length; i++)
            {
                boids.Add(zionBoss[i].GetComponent<Boid>());
            }

            foreach (Boid b in boids)
            {
                b.maxSpeed = (float)UnityEngine.Random.Range(8, 12);
            }

            foreach (GameObject c in cameras)
            {
                c.tag = "Cam_0";
            }
        }
    
    IEnumerator WaitForFade()
    {
        changeScene = true;
        yield return new WaitForSeconds(1);
        ChangeScene(sceneIndex);

    }

    void ChangeScene(int Index)
    {
        SceneManager.LoadScene(Index);
    }
    

    private void Update()
    {
        if (changeScene == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (_EFDeathCount <= 0)
                {
                    _victor = "Zion";
                    FadeScript fs = Fade.GetComponent<FadeScript>();
                    fs.Fade(true);
                    sceneIndex = 3;
                    StartCoroutine(WaitForFade());
                }

                if (_ZionDeathCount <= 0)
                {                  
                    FadeScript fs = Fade.GetComponent<FadeScript>();
                    fs.Fade(true);
                    sceneIndex = 2;
                    StartCoroutine(WaitForFade());
                }
            }
        }
    }
}
