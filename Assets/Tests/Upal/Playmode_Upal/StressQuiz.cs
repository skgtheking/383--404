using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

// Generate 100 instances of Quiz questions and Answers to make sure when the game runs, its able to handle the load

public class StressQuiz
{
    private QuestionGenerator questionGenerator;

    [SetUp]
    public void Setup()
    {
        // Create an instance of the QuestionGenerator
        GameObject questionGeneratorObject = new GameObject();
        questionGenerator = questionGeneratorObject.AddComponent<QuestionGenerator>();
        questionGenerator.InitializeQuestions(); // Initialize with sample questions for testing
    }

    [UnityTest]
    public IEnumerator StressQuizWithEnumeratorPasses()
    {
        // Number of times you want to call GetRandomQuestion
        int numberOfIterations = 100;

        for (int i = 0; i < numberOfIterations; i++)
        {
            string randomQuestion = questionGenerator.GetRandomQuestion();
            Debug.Log("Random Question: " + randomQuestion);
            Assert.IsNotNull(randomQuestion); // Ensure it's not null
            Assert.IsFalse(string.IsNullOrEmpty(randomQuestion)); // Ensure it's not empty
            
        }

        yield return null;
    }

    [TearDown]
    public void Teardown()
    {
        // Clean up after the test
        GameObject.Destroy(questionGenerator.gameObject);
    }
}
