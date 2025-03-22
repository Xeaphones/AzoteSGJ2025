using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int currentActionPointPolueur = 7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    public int getCurrentActionPoints() {
        return currentActionPointPolueur;
    }
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
