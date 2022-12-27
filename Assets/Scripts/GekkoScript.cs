using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GekkoScript : MonoBehaviour
{
    private Camera _camera;
    
    private void Start()
    {
        _camera = Camera.main;
        _camera.transform.eulerAngles = new Vector3(21.85f, -1.3f, 0);
    }
}
