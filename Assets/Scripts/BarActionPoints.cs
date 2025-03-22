using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class BarActionPoints : MonoBehaviour {
    
    public Sprite crossSprite;
    public Sprite circleSprite;
    private int maxActionPoints = 15;
    public Image[] Images;
    
    
    public void DrawActionPoints() {
        if(GameManager.Instance.IsUnityNull()) return;
        
        for (int i = 0; i < Images.Length; i++) {
            if (i < GameManager.Instance.getCurrentActionPoints()) {
                // Images[i].sprite = circleSprite;
                Images[i].sprite = circleSprite;
            } else {
                Images[i].sprite = crossSprite;
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
