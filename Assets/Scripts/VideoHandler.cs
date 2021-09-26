using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDrag()
    {
        VideoPlayerController.Instance.isDragged = true;
    }
}
