using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class PuzzleChecker : GridRandomizer
{
    private Canvas puzzleCanvas;
    private TextMeshProUGUI grid1;
    private TextMeshProUGUI grid2;
    private TextMeshProUGUI grid4;
    private TextMeshProUGUI grid7;
    private TextMeshProUGUI grid8;
    private TMP_InputField input3;
    private TMP_InputField input5;
    private TMP_InputField input6;
    private TMP_InputField input9;
    private Button check;
    public static UnityEvent puzzleSolved = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        RandomizeGrids();
        puzzleCanvas = GameObject.FindWithTag("Puzzle").GetComponent<Canvas>();
        check = GameObject.FindWithTag("checkPuzzle").GetComponent<Button>();
        check.onClick.AddListener(checkPuzzle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void checkPuzzle()
    {
        grid1 = GameObject.FindWithTag("grid1").GetComponent<TextMeshProUGUI>();
        // Get the value of grid1 in integer
        int grid1Value = int.Parse(grid1.text);
        grid2 = GameObject.FindWithTag("grid2").GetComponent<TextMeshProUGUI>();
        // Get the value of grid2 in integer
        int grid2Value = int.Parse(grid2.text);
        grid4 = GameObject.FindWithTag("grid4").GetComponent<TextMeshProUGUI>();
        // Get the value of grid4 in integer
        int grid4Value = int.Parse(grid4.text);
        grid7 = GameObject.FindWithTag("grid7").GetComponent<TextMeshProUGUI>();
        // Get the value of grid7 in integer
        int grid7Value = int.Parse(grid7.text);
        grid8 = GameObject.FindWithTag("grid8").GetComponent<TextMeshProUGUI>();
        // Get the value of grid8 in integer
        int grid8Value = int.Parse(grid8.text);
        input3 = GameObject.FindWithTag("input3").GetComponent<TMP_InputField>();
        // Get the value of input3 in integer
        int input3Value = int.Parse(input3.text);
        input5 = GameObject.FindWithTag("input5").GetComponent<TMP_InputField>();
        // Get the value of input5 in integer
        int input5Value = int.Parse(input5.text);
        input6 = GameObject.FindWithTag("input6").GetComponent<TMP_InputField>();
        // Get the value of input6 in integer
        int input6Value = int.Parse(input6.text);
        input9 = GameObject.FindWithTag("input9").GetComponent<TMP_InputField>();
        // Get the value of input9 in integer
        int input9Value = int.Parse(input9.text);
        // Check if the sum of grid1, grid2, grid4, grid7, and grid8 is equal to the sum of input3, input5, input6, and input9
        if (grid1Value + grid2Value + grid4Value + grid7Value + grid8Value == input3Value + input5Value + input6Value + input9Value)
        {
            puzzleCanvas.gameObject.SetActive(false);
            LogPuzzleStatus();
        }
        else
        {
            Debug.Log("Puzzle Not Solved!");
        }
    }
    private void LogPuzzleStatus()
    {
        Debug.Log("Puzzle Solved!");
        puzzleSolved.Invoke();
    }
}
