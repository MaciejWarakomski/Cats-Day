using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] 
    private Transform staticPuzzle;

    [SerializeField]
    bool onlyOnePuzzlePerLevel = false;

    [SerializeField]
    bool isItLevelWithColors = false;

    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    private bool locked;

    // Start is called before the first frame update
    void Start()
    {
        locked = false;
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if(Mathf.Abs(transform.position.x - staticPuzzle.position.x) <= 1f &&
            Mathf.Abs(transform.position.y - staticPuzzle.position.y) <= 1f)
        {
            transform.position = new Vector2(staticPuzzle.position.x, staticPuzzle.position.y);
            locked = true;
            if (onlyOnePuzzlePerLevel)
            {
                FindObjectOfType<LevelLoader>().LoadNextScene();
            }
            else if (isItLevelWithColors)
            {
                Destroy(gameObject);
                FindObjectOfType<PuzzleController>().PuzzleMatched();
                FindObjectOfType<SpawnerColorPuzzle>().ShowNextPuzzle();
            }
            else
            {
                FindObjectOfType<PuzzleController>().PuzzleMatched();
            }
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}
