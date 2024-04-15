using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using UnityEngine.UI;

// Stress test for the QandA Canvas no change if wrong answer is given

public class StressQuizCanvas
{
    private QuestionGenerator questionGenerator;
    private Canvas QandA_Canvas;
    private TextMeshProUGUI questionText;
    private Button submit;
    private TMP_InputField answer;
    private string correctAnswer;
    [SetUp]
    public void Setup()
    {
        
       // Create an instance of the QuestionGenerator
        GameObject questionGeneratorObject = new GameObject();
        questionGenerator = questionGeneratorObject.AddComponent<QuestionGenerator>();
        //Tag for QuestionGenerator
        questionGenerator.tag = "QuestionGenerator";
        questionGenerator.InitializeQuestions(); // Initialize with sample questions for testing
        // Create an instance of the QandA_Canvas
        GameObject QandA_CanvasObject = new GameObject();
        QandA_Canvas = QandA_CanvasObject.AddComponent<Canvas>();
        QandA_Canvas.tag = "QandA_Canvas";
        // Create an instance of the questionText
        GameObject questionTextObject = new GameObject();
        questionText = questionTextObject.AddComponent<TextMeshProUGUI>();
        questionText.tag = "Question";
        // Create an instance of the submit
        GameObject submitObject = new GameObject();
        submit = submitObject.AddComponent<Button>();
        submit.tag = "SubmitButton";
        // Create an instance of the answer
        GameObject answerObject = new GameObject();
        answer = answerObject.AddComponent<TMP_InputField>();
        answer.tag = "AnswerField";
    }

    [UnityTest]
    public IEnumerator OpenColseQuiz()
    {
        // QandA qandaInstance = new QandA();
        // qandaInstance.Start();
        // // 100 times qandaInstance.OnButtonClick();
        // for (int i = 0; i < 100; i++)
        // {
        //     //generate random 5 letter string, like abcde
        //     string randomText = System.Guid.NewGuid().ToString().Substring(0, 5);
        //     answer.text = randomText;
        //     qandaInstance.Test_Question();
        //     Debug.Log("Correct Answer: " + qandaInstance.correctAnswer);
        //     qandaInstance.OnButtonClick();
        //     Assert.AreNotEqual(qandaInstance.correctAnswer, answer.text);
        // }
        yield return null;
    }
}
