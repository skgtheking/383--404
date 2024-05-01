using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionGenerator : MonoBehaviour, IQuestionGenerator
{
    public List<string> questionAndAnswers = new List<string>();
    public string textFilePath = "Assets/src/Upal/Code/song_lines.txt"; // Path to your text file
    void Start()
    {
        InitializeQuestions();
    }

    public void InitializeQuestions()
    {
        // Read lines from the text file
        string[] lines = File.ReadAllLines(textFilePath);
        // Add each line to the questionAndAnswers list
        questionAndAnswers.AddRange(lines);
    }


    public string GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionAndAnswers.Count);
        return questionAndAnswers[randomIndex];
    }
}
