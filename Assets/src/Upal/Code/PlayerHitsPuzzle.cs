using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitsPuzzle : MonoBehaviour
{
    private Canvas puzzleCanvas;
    private ChallengeManager challengeManager;
    // Start is called before the first frame update
    void Start()
    {
        puzzleCanvas = GameObject.FindWithTag("Puzzle").GetComponent<Canvas>();
        puzzleCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PuzzleCollider") && challengeManager.puzzlechallenge == false)
        {
            puzzleCanvas.gameObject.SetActive(true);
        }
    }
}
