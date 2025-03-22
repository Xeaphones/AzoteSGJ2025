using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class BarActionPoints : MonoBehaviour {
    
    public Sprite crossSprite;
    public Sprite circleSprite;
    private int maxActionPoints = 15;
    private int currentActionPoints = 7;
    public Image[] Images;
    private Sprite FULLHD;
    
    
    public void UpdateActionPoints(int points) {
        currentActionPoints = points;
    }

    public void DrawActionPoints() {
        for (int i = 0; i < Images.Length; i++) {
            if (i < currentActionPoints) {
                // Images[i].sprite = circleSprite;
                Images[i].sprite = circleSprite;
            } else {
                Images[i].sprite = crossSprite;
            }
        }
    }
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FULLHD = Resources.Load<Sprite>("FULLHD");
    }

    // Update is called once per frame
    void Update() {
        DrawActionPoints();
    }
}
