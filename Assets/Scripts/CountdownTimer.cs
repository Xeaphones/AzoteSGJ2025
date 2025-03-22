using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 300f;
    private float timeLeft;

    public TMP_Text timerText;
    public GameObject victoryPanel;
    public Button newGameButton;
    public Button menuButton;

    void Start()
    {
        timeLeft = totalTime;

        // Cacher le panneau au démarrage
        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        // Lier les boutons
        newGameButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("MenuScene"));
    }

    void Update()
    {
        if (timeLeft > 1)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay(timeLeft);
        }
        else
        {
            ShowVictoryPopup();
        }
    }

    void UpdateTimerDisplay(float time)
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    void ShowVictoryPopup()
    {
        timeLeft = 0;

        if (victoryPanel != null && !victoryPanel.activeSelf)
        {
            victoryPanel.SetActive(true);
        }
    }
}
