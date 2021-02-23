using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField]
    private int numberOfPuzzles;

    private int counterMatchingPuzzles = 0;


    public void PuzzleMatched()
    {
        counterMatchingPuzzles++;
        if (counterMatchingPuzzles >= numberOfPuzzles)
        {
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }

    public int GetNumberOfPuzzles()
    {
        return numberOfPuzzles;
    }
}
