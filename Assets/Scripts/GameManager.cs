using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text questionText;
    public Image questionImage;
    public TMPro.TMP_Text feedbackText;
    public Button[] optionsButton;
    private int score = 0;

    [Header("Questions")]
    public List<QuestionData> questionDataList = new List<QuestionData>();
    private int currentQuestionIndex = 0;

    private void Start()
    {
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        feedbackText.text = "";

        QuestionData q = questionDataList[currentQuestionIndex];

        questionText.text = q.questionText;
        questionImage.sprite = q.questionImage;

        for (int i = 0; i < optionsButton.Length; i++)
        {
            optionsButton[i].GetComponentInChildren<TMPro.TMP_Text>().text = q.options[i];
            int index = i;
            optionsButton[i].onClick.RemoveAllListeners();
            optionsButton[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        QuestionData q = questionDataList[currentQuestionIndex];

        if (selectedIndex == q.correctAnswerIndex)
        {
            feedbackText.text = "Correcto!";
            feedbackText.color = Color.green;
            score++;
        }
        else
        {
            feedbackText.text = "Incorrecto! Inténtalo otra vez.";
            feedbackText.color = Color.red;
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < questionDataList.Count)
        {
            Invoke(nameof(DisplayQuestion), 1.5f); // întârziere între întrebări
        }
        else
        {
            Invoke(nameof(ShowFinalMessage), 1.5f); // afișează mesajul final
        }
    }
    void ShowFinalMessage()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("TotalQuestions", questionDataList.Count);
        SceneManager.LoadScene("EndScene");
    }
}
