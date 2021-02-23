using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerColorPuzzle : MonoBehaviour
{
    [SerializeField]
    List<GameObject> coloredPieces;

    [SerializeField]
    Transform minXY;

    [SerializeField]
    Transform maxXY;

    int numberOfMatches;
    float minX;
    float maxX;
    float minY;
    float maxY;

    private void Start()
    {
        numberOfMatches = FindObjectOfType<PuzzleController>().GetNumberOfPuzzles();
        minX = minXY.position.x;
        minY = minXY.position.y;
        maxX = maxXY.position.x;
        maxY = maxXY.position.y;
        ShowNextPuzzle();
    }

    public void ShowNextPuzzle()
    {
        Vector3 newPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        Instantiate(coloredPieces[Random.Range(0, coloredPieces.Count)], newPosition, Quaternion.identity);
    }
}
