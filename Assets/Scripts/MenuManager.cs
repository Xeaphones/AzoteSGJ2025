using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenManual()
    {
        // À adapter si tu veux une autre scène ou une popup
        Debug.Log("Manuel à afficher ici");
    }
}
