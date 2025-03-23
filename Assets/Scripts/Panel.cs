using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public bool isHudPolueur = false;

    private Dictionary<string, (string, Sprite)> currentControllerInfo; // = new Dictionary<string, (string, Sprite)>();
    private Dictionary<string, (string, Sprite)> infoTerrain;
    
    public TextMeshProUGUI controllerText;
    public Image controllerImage;
    public TextMeshProUGUI terrainText;
    public Image terrainImage;
    
    private string getCurrentController()
    {
        if (GameManager.instance.IsUnityNull())
        {
            return "";
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
        Dictionary<string, (string, Sprite)> infoControllerPolueur = new Dictionary<string, (string, Sprite)>
        {
            { "A", ("Industrie: Creer une industrie", Resources.Load<Sprite>("Images/Hud/A")) },
            { "B", ("Feu: creer une industrie", Resources.Load<Sprite>("Images/Hud/B")) },
            { "X", ("X: Creer une industrie", Resources.Load<Sprite>("Images/Hud/X")) },
            { "Y", ("Y: Creer une industrie", Resources.Load<Sprite>("Images/Hud/Y")) },
        };
        Dictionary<string, (string, Sprite)> infoControllerCleaner = new Dictionary<string, (string, Sprite)>
        {
            { "A", ("A: Creer une industrie", Resources.Load<Sprite>("Images/Hud/A")) },
            { "B", ("B: Creer une industrie", Resources.Load<Sprite>("Images/Hud/B")) },
            { "X", ("X: Creer une industrie", Resources.Load<Sprite>("Images/Hud/X")) },
            { "Y", ("Y: Creer une industrie", Resources.Load<Sprite>("Images/Hud/Y")) },
        };
        
        currentControllerInfo = isHudPolueur ? infoControllerPolueur : infoControllerCleaner;

        infoTerrain = new Dictionary<string, (string, Sprite)>{
            {"Foret", ("Foret: 0.5 amoniaque", Resources.Load<Sprite>("Images/Hud/B"))},
            {"Desert", ("Desert: 0.2 amoniaque", Resources.Load<Sprite>("Images/Hud/B"))},
            {"Plaine", ("Plaine: 0.3 amoniaque", Resources.Load<Sprite>("Images/Hud/B"))},
            {"Montagne", ("Montagne: 0.4 amoniaque", Resources.Load<Sprite>("Images/Hud/B"))},
            {"Eau", ("Eau: 0.1 amoniaque", Resources.Load<Sprite>("Images/Hud/B"))}
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
