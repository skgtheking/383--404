using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

// Test puzzle values are solveable by user

public class ValueTest
{
    
    // A Test behaves as an ordinary method
    [Test]
    public void ValueTestPuzzle()
    {
        //Replicate the test for 50 times
        for (int i = 0; i < 50; i++)
        {
            // Use the Assert class to test conditions
            GameObject gridRandomizerObject = new GameObject();
            GridRandomizer gridRandomizer = gridRandomizerObject.AddComponent<GridRandomizer>();
            gridRandomizer.RandomizeGrids();
            TextMeshProUGUI grid1 = GameObject.FindWithTag("grid1").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI grid2 = GameObject.FindWithTag("grid2").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI grid4 = GameObject.FindWithTag("grid4").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI grid7 = GameObject.FindWithTag("grid7").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI grid8 = GameObject.FindWithTag("grid8").GetComponent<TextMeshProUGUI>();
            int grid1Value = int.Parse(grid1.text);
            int grid2Value = int.Parse(grid2.text);
            int grid4Value = int.Parse(grid4.text);
            int grid7Value = int.Parse(grid7.text);
            int grid8Value = int.Parse(grid8.text);
            //assert sum is less than 36
            Assert.Less(grid1Value + grid2Value + grid4Value + grid7Value + grid8Value, 36);
        }
        
    }
}
