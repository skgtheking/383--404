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
    
    private TMP_InputField answer;
    private IQuestionGenerator questionGenerator;
    public string correctAnswer;
    public string newQuestion;
    public static UnityEvent questionAnswered = new UnityEvent();
    public QandA(IQuestionGenerator generator)
    {
        questionGenerator = generator;
    }
    public void Start()
    {
        
        QandA_Canvas = GameObject.FindWithTag("QandA_Canvas").GetComponent<Canvas>();
        questionText = GameObject.FindWithTag("Question").GetComponent<TextMeshProUGUI>();
        
        answer = GameObject.FindWithTag("AnswerField").GetComponent<TMP_InputField>();
        questionGenerator = GameObject.FindWithTag("QuestionGenerator").GetComponent<IQuestionGenerator>();
        QandA_Canvas.gameObject.SetActive(false);
        
    }
    
    public void DisplayQuestion()
    {
            QandA_Canvas.gameObject.SetActive(true);
            // Get a random question from the QuestionGenerator
            newQuestion = questionGenerator.GetRandomQuestion();
            if (!string.IsNullOrEmpty(newQuestion))
            {
                string[] questionParts = newQuestion.Split(',');
                questionText.text = questionParts[0]; // Display the question part
                Debug.Log(questionParts[0]);
                correctAnswer = questionParts[1]; // Store the correct answer
                Debug.Log(correctAnswer);
            }
            else
            {
                Debug.LogError("No question found!");
            }
    }

    public void CheckQuestion()
    {
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
