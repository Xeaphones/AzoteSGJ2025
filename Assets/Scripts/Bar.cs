using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{

    public int min(int a, int b)
    {
        return a < b ? a : b;
    }

    public Image NH3Image;
    public Image PMImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        RectTransform rectTransform = NH3Image.rectTransform;
        rectTransform.pivot = new Vector2(0, 0.5f);
        
        RectTransform rectTransform2 = PMImage.rectTransform;
        rectTransform.pivot = new Vector2(0, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.instance.IsUnityNull())
        {
            return;
        }
        
        float newWidth = min(GameManager.instance.totalAmmoniac, GameManager.instance.maxAmmoniac) / (float)GameManager.instance.maxAmmoniac * 430;
        RectTransform rectTransform = NH3Image.rectTransform;
        rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y);
        
        float newWidth2 = min(GameManager.instance.totalToxicParticles, GameManager.instance.maxToxicParticles) / (float)GameManager.instance.maxToxicParticles * 380;
        RectTransform rectTransform2 = PMImage.rectTransform;
        rectTransform2.sizeDelta = new Vector2(newWidth2, rectTransform2.sizeDelta.y);
    }
}
