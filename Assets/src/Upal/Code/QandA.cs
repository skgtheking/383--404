using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QandA : MonoBehaviour
{
    private Canvas QandA_Canvas;
    private TextMeshProUGUI questionText;
    private Button submit;
    private TMP_InputField answer;

    public QuestionGenerator questionGenerator;
    private string correctAnswer;

    private void Start()
    {
        
        QandA_Canvas = GameObject.FindWithTag("QandA_Canvas").GetComponent<Canvas>();
        questionText = GameObject.FindWithTag("Question").GetComponent<TextMeshProUGUI>();
        submit = GameObject.FindWithTag("SubmitButton").GetComponent<Button>();
        answer = GameObject.FindWithTag("AnswerField").GetComponent<TMP_InputField>();

        QandA_Canvas.gameObject.SetActive(false);

        

        submit.onClick.AddListener(OnButtonClick);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("object"))
        {
            QandA_Canvas.gameObject.SetActive(true);

            // Get a random question from the QuestionGenerator
            string newQuestion = questionGenerator.GetRandomQuestion();
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

    private void OnButtonClick()
    {
        Debug.Log("Button Clicked");

        string inputText = answer.text.ToLower();

        // Get the current question from the QuestionGenerator
        string currentQuestion = questionText.text;

        if (!string.IsNullOrEmpty(currentQuestion))
        {
            if (inputText.Equals(correctAnswer.ToLower()))
            {
                Debug.Log("Correct Answer");
                answer.text = "";
                QandA_Canvas.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Incorrect Answer");
            }

            Debug.Log("Input Text: " + inputText);
        }
    }
}
