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
        // Add sample questions with answers
        questionAndAnswers.Add("Imagine there's no --- It's easy if you try-John Lennon,Heaven");
        questionAndAnswers.Add("Now I'm floating like a --- Never hit so hard in love-Sia,Chandelier");
        questionAndAnswers.Add("Cause all of me --- All of you-John Legend,Loves");
        questionAndAnswers.Add("But baby, now we got --- You know it ..-Taylor Swift,Blank Space");
        questionAndAnswers.Add("Cause darling I'm a nightmare dressed like a --- Your worst nightmare-Taylor Swift,Blank Space");
        questionAndAnswers.Add("I got the eye of the --- A fighter-Demi Lovato,Roar");
        questionAndAnswers.Add("I got the --- Like Jagger-Maroon 5,Moves");
        questionAndAnswers.Add("Said no more counting --- We'll be counting stars-OneRepublic,Stars");
        questionAndAnswers.Add("So baby. pull me --- This is a hurricane-Ed Sheeran,Photograph");
        questionAndAnswers.Add("And I will always --- Even if it's just in your-Charlie Puth,See You Again");
    }


    public string GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionAndAnswers.Count);
        return questionAndAnswers[randomIndex];
    }
}
