using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenMnager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Button restartButton;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        int totalQuestions = PlayerPrefs.GetInt("TotalQuestions", 0);

        scoreText.text = $"Tu puntuación: {finalScore} / {totalQuestions}";

        restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu"); // sau "GameScene" direct dacă nu ai meniu
        });
    }
}
