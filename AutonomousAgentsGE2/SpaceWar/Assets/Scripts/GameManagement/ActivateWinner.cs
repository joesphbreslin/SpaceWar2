using UnityEngine.UI;
using UnityEngine;

public class ActivateWinner : MonoBehaviour {

    public GameObject GundamEF;
    public GameObject GundamZion;
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();

        if (GameManager._victor == "EF")
        {
            text.text = "EARTH";
            GundamEF.SetActive(true);
            GundamZion.SetActive(false);
        }
        else if (GameManager._victor == "Zion")
        {
            text.text = "ZION";
            GundamEF.SetActive(false);
            GundamZion.SetActive(true);
        }
    }
}
