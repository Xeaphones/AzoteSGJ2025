using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeftPanel : MonoBehaviour
{
    private Dictionary<string, string> infoManette = new Dictionary<string, string>{
        {"A", "Placer Industrie: Créer de l'amoniaque"},
        {"B", "Placer puit: Enleve de l'amoniaque"}
    };
    
    private Dictionary<string, string> infoTerrain = new Dictionary<string, string>{
        {"Foret", "Foret: 0.5 amoniaque"},
        {"Desert", "Desert: 0.2 amoniaque"},
        {"Plaine", "Plaine: 0.3 amoniaque"},
        {"Montagne", "Montagne: 0.4 amoniaque"},
        {"Eau", "Eau: 0.1 amoniaque"}
    };
    
    private string indexManetteInfo = "";
    private string indexTerrainInfo = "";
    private string currentManetteInfo = "";
    private string currentTerrainInfo = "";
    
    public void ChangeIndexManetteInfo(string index) {
        indexManetteInfo = index;
    }
    
    public void ChangeIndexTerrainInfo(string index) {
        indexTerrainInfo = index;
    }
    
    public TextMeshProUGUI terrainText;
    public TextMeshProUGUI manetteText;
    public TextMeshProUGUI terrainImage;
    public TextMeshProUGUI manetteImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        
    }

    // Update is called once per frame
    private void Update() {
        if(infoManette.ContainsKey(indexManetteInfo)) {
            currentManetteInfo = infoManette[indexManetteInfo];
        }
        else
        {
            currentManetteInfo = "";
        }
        
        if(infoTerrain.ContainsKey(indexTerrainInfo)) {
            currentTerrainInfo = infoTerrain[indexTerrainInfo];
        }
        else
        {
            currentTerrainInfo = "";
        }
        
        terrainText.text = currentTerrainInfo;
        manetteText.text = currentManetteInfo;
        
        
    }
}
