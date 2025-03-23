using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public bool isHudPolueur = false;

    private Dictionary<int, (string, Sprite)> currentControllerInfo; // = new Dictionary<string, (string, Sprite)>();
    private Dictionary<string, (string, Sprite)> infoTerrain;
    
    public TextMeshProUGUI controllerText;
    public Image controllerImage;
    public TextMeshProUGUI terrainText;
    public Image terrainImage;
    
    private int getCurrentController()
    {
        if (GameManager.instance.IsUnityNull())
        {
            return 0;
        }
        return isHudPolueur ? GameManager.instance.GetCurrentControllerPolueur() : GameManager.instance.GetCurrentControllerCleaner();
    }
    
    private string getCurrentTerrain()
    {
        if (GameManager.instance.IsUnityNull())
        {
            return "";
        }
        return isHudPolueur ? GameManager.instance.GetCurrentTerrainPolueur() : GameManager.instance.GetCurrentTerrainCleaner();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        // Le chemin des images est Assets/Resources/Images/Hud
        Dictionary<int, (string, Sprite)> infoControllerPolueur = new Dictionary<int, (string, Sprite)>
        {
            { 3, ("Industrie: Creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-pollutr-A")) },
            { 2, ("Feu: creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-pollutr-B")) },
            { 4, ("X: Creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-pollutr-X")) },
            { 1, ("Y: Creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-pollutr-Y")) },
        };
        Dictionary<int, (string, Sprite)> infoControllerCleaner = new Dictionary<int, (string, Sprite)>
        {
            { 3, ("A: Creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-cleanr-A")) },
            { 2, ("B: Creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-cleanr-B")) },
            { 4, ("X: Creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-cleanr-X")) },
            { 1, ("Y: Creer une industrie", Resources.Load<Sprite>("Images/Hud/boutons-cleanr-Y")) },
        };
        
        currentControllerInfo = isHudPolueur ? infoControllerPolueur : infoControllerCleaner;

        infoTerrain = new Dictionary<string, (string, Sprite)>{
            {"Vide", ("Rien de particulier", Resources.Load<Sprite>("Images/Hud/Vide"))},
            {"Foret", ("élimine les particules au contact", Resources.Load<Sprite>("Images/Hud/Foret"))},
            {"BatPluie", ("Crée de la pluie qui élimine l’ammoniac et éteint les feux", Resources.Load<Sprite>("Images/Hud/BatPluie"))},
            {"Cloud1", ("Nuage", Resources.Load<Sprite>("Images/Hud/Cloud1"))},
            {"Cloud2", ("Nuage", Resources.Load<Sprite>("Images/Hud/Cloud2"))},
            {"Elevage", ("Crée de l’ammoniac (plus efficace pendant l’été)", Resources.Load<Sprite>("Images/Hud/Elevage"))},
            {"Industrie", ("Crée de l’ammoniac de manière constante", Resources.Load<Sprite>("Images/Hud/Industrie"))},
            {"Entonoir", ("Élimine l’ammoniac entrant dans les cellules adjacentes", Resources.Load<Sprite>("Images/Hud/Entonoir"))},
            {"Incendie1", ("Feu", Resources.Load<Sprite>("Images/Hud/Incendie1"))},
            {"Incendie2", ("Feu", Resources.Load<Sprite>("Images/Hud/Incendie2"))},
        };
        
    }
                
    // Update is called once per frame
    private void Update() {
        // Terrain et Manette informations
        if(currentControllerInfo.ContainsKey(getCurrentController())) {
            controllerText.text = currentControllerInfo[getCurrentController()].Item1;
            controllerImage.sprite = currentControllerInfo[getCurrentController()].Item2;
        }
        
        if(infoTerrain.ContainsKey(getCurrentTerrain())) {
            // Terrain
            terrainText.text = infoTerrain[getCurrentTerrain()].Item1;
            terrainImage.sprite = infoTerrain[getCurrentTerrain()].Item2;
        }
        
        // Barre des points d'actions
    }
}
