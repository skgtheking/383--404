using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitsPuzzle : MonoBehaviour
{
    private Canvas puzzleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        puzzleCanvas = GameObject.FindWithTag("Puzzle").GetComponent<Canvas>();
        puzzleCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PuzzleCollider") && !ChallengeManager.puzzleStatus())
        {
            puzzleCanvas.gameObject.SetActive(true);
        }
    }
}
