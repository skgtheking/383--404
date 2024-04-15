using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    public bool puzzlechallenge = false;
    public bool quizchallenge = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnPuzzleSolved()
    {
        puzzlechallenge = true;
        Debug.Log("Puzzle Solved and Confirmed from Challenge Manager");
    }
    void OnQuizSolved()
    {
        quizchallenge = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        PuzzleChecker.puzzleSolved.AddListener(OnPuzzleSolved);
        Debug.Log("Puzzle Solve Invoked"); 
    }
    private void OnDisable()
    {
        PuzzleChecker.puzzleSolved.RemoveListener(OnPuzzleSolved);
    }
}
