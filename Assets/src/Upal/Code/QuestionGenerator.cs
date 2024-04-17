using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour, IQuestionGenerator
{
    public List<string> questionAndAnswers = new List<string>();

    void Start()
    {
        InitializeQuestions();
    }

    public void InitializeQuestions()
    {
        // Add 10 sample questions with answers
        questionAndAnswers.Add("What's the capital of France?,Paris");
        questionAndAnswers.Add("Which planet is known as the Red Planet?,Mars");
        questionAndAnswers.Add("Who painted the Mona Lisa?,Leonardo da Vinci");
        questionAndAnswers.Add("What is the largest mammal in the world?,Blue whale");
        questionAndAnswers.Add("Who wrote 'Romeo and Juliet'?,William Shakespeare");
        questionAndAnswers.Add("What is the currency of Japan?,Japanese Yen");
        questionAndAnswers.Add("Which country is known as the 'Land of the Rising Sun'?,Japan");
        questionAndAnswers.Add("What is the largest ocean on Earth?,Pacific Ocean");
        questionAndAnswers.Add("Who invented the telephone?,Alexander Graham Bell");
        questionAndAnswers.Add("What is the capital of Australia?,Canberra");
    }

    public string GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionAndAnswers.Count);
        return questionAndAnswers[randomIndex];
    }
}
