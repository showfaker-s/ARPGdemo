using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Camera minimapCamera;
    public void OnZoomInClick()
    {
        minimapCamera.orthographicSize--;
    }
    public void OnZoomOutClick()
    {
        minimapCamera.orthographicSize++;
    }
}
