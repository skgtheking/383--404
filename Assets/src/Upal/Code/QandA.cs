using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QandA : MonoBehaviour
{
    private Canvas QandA_Canvas;
    private TextMeshProUGUI questionText;
    private Button submit;
    private TMP_InputField answer;
    private ChallengeManager challengeManager;
    private QuestionGenerator questionGenerator;
    public string correctAnswer;
    public string newQuestion;
    public static UnityEvent questionAnswered = new UnityEvent();
    public void Start()
    {
        
        QandA_Canvas = GameObject.FindWithTag("QandA_Canvas").GetComponent<Canvas>();
        questionText = GameObject.FindWithTag("Question").GetComponent<TextMeshProUGUI>();
        submit = GameObject.FindWithTag("SubmitButton").GetComponent<Button>();
        answer = GameObject.FindWithTag("AnswerField").GetComponent<TMP_InputField>();
        questionGenerator = GameObject.FindWithTag("QuestionGenerator").GetComponent<QuestionGenerator>();
        QandA_Canvas.gameObject.SetActive(false);
        submit.onClick.AddListener(OnButtonClick);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("object") && challengeManager.quizchallenge == false)
        {
            QandA_Canvas.gameObject.SetActive(true);

            // Get a random question from the QuestionGenerator
            newQuestion = questionGenerator.GetRandomQuestion();
            if (!string.IsNullOrEmpty(newQuestion))
            {
                string[] questionParts = newQuestion.Split(',');
                questionText.text = questionParts[0]; // Display the question part
                correctAnswer = questionParts[1]; // Store the correct answer
            }
            else
            {
                Debug.LogError("No question found!");
            }
        }
    }
    public void Test_Question()
    {
            QandA_Canvas.gameObject.SetActive(true);

            // Get a random question from the QuestionGenerator
            newQuestion = questionGenerator.GetRandomQuestion();
            if (!string.IsNullOrEmpty(newQuestion))
            {
                string[] questionParts = newQuestion.Split(',');
                questionText.text = questionParts[0]; // Display the question part
                correctAnswer = questionParts[1]; // Store the correct answer
            }
            else
            {
                Debug.LogError("No question found!");
            }
    }

    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");

        string inputText = answer.text.ToLower();
        Debug.Log("Input Text: " + inputText);
        // Get the current question from the QuestionGenerator
        string currentQuestion = questionText.text;

        if (!string.IsNullOrEmpty(currentQuestion))
        {
            if (inputText.Equals(correctAnswer.ToLower()))
            {
                Debug.Log("Correct Answer");
                answer.text = "";
                QandA_Canvas.gameObject.SetActive(false);
                LogQuestionStatus();
            }
            else
            {
                Debug.Log("Incorrect Answer");
            }

            Debug.Log("Input Text: " + inputText);
        }
    }
    private void LogQuestionStatus()
    {
        Debug.Log("Question Answered");
        questionAnswered.Invoke();
    }
}
