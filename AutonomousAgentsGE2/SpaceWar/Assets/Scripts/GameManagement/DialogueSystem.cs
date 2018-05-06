using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour {

    public Color red, blue;
    string character;
    public Text text;
    public Image panel, profile;
    public Sprite amuroRay, charAznable;
    public float timeBetweenSentances, startDelay;
    
    int index;
    public GameObject fadeObj;
    [TextArea]
    public string[] sentances;

    [TextArea]
    public string zionOpeningText, efOpeningText;

    void CharacterSelection()
    {
        char c = sentances[index][0];        
            if (c == '_')
                character = "Amuro Ray";
            else
                character = "Char Aznable";
    }
    void UpdateText()
    {
        if (character == "Amuro Ray")
        {
            sentances[index] = sentances[index].Substring(1);
        }
        text.text = sentances[index];
    }

    private void UpdatePanelProfile()
    {
        if (character == "Amuro Ray") {
            profile.sprite = amuroRay;
            panel.CrossFadeColor(blue, .2f, true, true);
        }
        else { profile.sprite = charAznable;
            panel.CrossFadeColor(red, .2f, true, true); }
    }

    void Start () {
        panel.enabled = false;
        profile.enabled = false;
        text.enabled = false;
        StartCoroutine(StartDelay());
    }

    IEnumerator DialogueScene_1()
    {
        CharacterSelection();
        UpdateText();
        UpdatePanelProfile();
        panel.enabled = true;
        profile.enabled = true;
        text.enabled = true;

        yield return new WaitForSeconds(timeBetweenSentances);
        index++;
        if (index < sentances.Length)
        {
            StartCoroutine(DialogueScene_1());
        }
        else
        {
            FadeScript fs = fadeObj.GetComponent<FadeScript>();
            fs.Fade(true);
            Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    //
    //MainSceneFunctions
    public void EFCelebrate(int zionDeathCount)
    {
        character = "Amuro Ray";
        UpdatePanelProfile();
        text.text = zionDeathCount + " " + sentances[UnityEngine.Random.Range(0, sentances.Length)];
    }

    public void ZionCelebrate(int efDeathCount)
    {
        character = "Char Aznable";
        UpdatePanelProfile();
        text.text = efDeathCount + " " + sentances[UnityEngine.Random.Range(0, sentances.Length)];
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        if(SceneManager.GetActiveScene().buildIndex == 0)
            StartCoroutine(DialogueScene_1());
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            StartCoroutine(DialogueScene_2());
    }

    IEnumerator DialogueScene_2()
    {
        OpeningStatement(false);
        panel.enabled = true;
        profile.enabled = true;
        text.enabled = true;
        yield return new WaitForSeconds(startDelay * 2);
        OpeningStatement(true);

    }

    public void OpeningStatement(bool isZion)
    {
        string openingText = isZion == true ? zionOpeningText : efOpeningText;
        character = isZion == true ? "Char Aznable" : "Amuro Ray";
        UpdatePanelProfile();
        text.text = openingText;
    }
}
