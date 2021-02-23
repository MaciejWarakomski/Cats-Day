using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizGoodAnswer : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}
