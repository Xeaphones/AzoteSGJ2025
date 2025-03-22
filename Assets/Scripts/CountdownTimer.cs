using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 10f; // 10 secondes par défaut (modifiable dans l'inspector)
    private float timeLeft;

    public string sceneToLoad; // nom de la scène à charger
    public TMP_Text timerText; // lien vers un UI Text pour afficher le temps (optionnel)

    void Start()
    {
        timeLeft = totalTime;
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
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void UpdateTimerDisplay(float time)
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
