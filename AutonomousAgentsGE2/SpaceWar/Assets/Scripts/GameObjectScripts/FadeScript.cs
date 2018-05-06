using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {  
    public float fadeTime = .3f;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        Fade(false);
    }

    public void Fade(bool FadeIn)
    {
        float alpha = FadeIn? 1 : 0;
        image.CrossFadeAlpha(alpha, fadeTime, true);
    }
}
