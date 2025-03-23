using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class BarActionPoints : MonoBehaviour {
    
    public bool IsBarCleaner = false;
    public Sprite actionPointSprite;
    public Sprite noActionPointSprite;
    public Image[] Images;
    
    public void DrawActionPoints() {
        if (GameManager.instance.IsUnityNull()) {
            Debug.LogError("Unity Null");
        }
        
        int currentActionPoints = IsBarCleaner ? GameManager.instance.GetCurrentActionPointsCleaner() : GameManager.instance.GetCurrentActionPointsPolueur();
        for (int i = 0; i < Images.Length; i++) {
            if (i < currentActionPoints) {
                // Images[i].sprite = circleSprite;
                Images[i].sprite = actionPointSprite;
            } else {
                Images[i].sprite = noActionPointSprite;
            }
        }
    }
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        DrawActionPoints();
    }
}
