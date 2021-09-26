using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleScript : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 newPosition;


    public bool isDraged = false;
    public static bool globalDragCallback = false;

    private void Start()
    {
        startPosition = new Vector3();
        newPosition = new Vector3();
        
        startPosition = transform.position;
        newPosition = startPosition;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, mousePosition.y, 0);
        isDraged = true;
        globalDragCallback = true;
    }
    private void OnMouseUpAsButton()
    {
        isDraged = false;
        globalDragCallback = false;
        transform.position = startPosition;
        /* wczesniej : transform.position = newPosition*/
    }
}
