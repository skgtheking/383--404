using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridRandomizer : MonoBehaviour
{
    private TextMeshProUGUI grid1;
    private TextMeshProUGUI grid2;
    private TextMeshProUGUI grid4;
    private TextMeshProUGUI grid7;
    private TextMeshProUGUI grid8;

    void Start()
    {
        RandomizeGrids();
    }

    void RandomizeGrids()
    {
        // Find and assign TextMeshProUGUI components by their corresponding tags
        grid1 = GameObject.FindWithTag("grid1").GetComponent<TextMeshProUGUI>();
        grid2 = GameObject.FindWithTag("grid2").GetComponent<TextMeshProUGUI>();
        grid4 = GameObject.FindWithTag("grid4").GetComponent<TextMeshProUGUI>();
        grid7 = GameObject.FindWithTag("grid7").GetComponent<TextMeshProUGUI>();
        grid8 = GameObject.FindWithTag("grid8").GetComponent<TextMeshProUGUI>();

        // Assign random values to each TextMeshProUGUI
        grid1.text = Random.Range(1, 5).ToString();
        grid2.text = Random.Range(1, 5).ToString();
        grid4.text = Random.Range(1, 5).ToString();
        grid7.text = Random.Range(1, 5).ToString();
        grid8.text = Random.Range(1, 5).ToString();
    }
}
