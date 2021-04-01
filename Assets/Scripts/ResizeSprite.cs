using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeSprite : MonoBehaviour
{
    public Camera cameras  = new Camera();
    public int TargetWidth = 640;
    public float pixelsToUnits = 100;

    private void Update()
    {
        int height = Mathf.RoundToInt(TargetWidth / (float)Screen.width * Screen.height);
        cameras.orthographicSize = height / pixelsToUnits / 2;
    }
    // Start is called before the first frame update
    
   
}
