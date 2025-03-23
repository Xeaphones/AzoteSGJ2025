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

    [Header("UI Dynamiques")]
    public TMP_Text bannerText;
    public TMP_Text descriptionText;
    public Image resultImage;

    [Header("Sprites des équipes")]
    public Sprite sylvestreSprite;
    public Sprite pollueurSprite;

    [Header("Boutons")]
    public Button newGameButton;
    public Button menuButton;

    private bool hasEnded = false;

    void Start()
    {
        timeLeft = totalTime;

        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        newGameButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("MenuScene"));
    }

    void Update()
    {
        if (hasEnded) return;

        if (timeLeft > 1f)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay(timeLeft);
        }
        else
        {
            ShowVictoryCleaners();
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

    void ShowVictoryCleaners()
    {
        hasEnded = true;
        timeLeft = 0f;

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            bannerText.text = "Victory Cleaners";
            descriptionText.text = "The polluters have lost";
            resultImage.sprite = sylvestreSprite;
        }
    }

    public void PollueursWin()
    {
        if (hasEnded) return;

        hasEnded = true;

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            bannerText.text = "Victoire Pollueurs";
            descriptionText.text = "The Cleaners have lost";
            resultImage.sprite = pollueurSprite;
        }
    }
}
