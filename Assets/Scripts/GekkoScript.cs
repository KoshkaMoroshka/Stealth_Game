using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GekkoScript : MonoBehaviour
{
    [SerializeField] private Vector3 offsetCamera;
    [SerializeField] private float radius;
    [SerializeField] private float angularSpeed;

    private float _angle = 0;
    private Camera _camera;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _camera.transform.position = transform.position + offsetCamera;
        _camera.transform.LookAt(this.transform);

        //positionX = transform.position.x * 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            offsetCamera -= new Vector3(1f, 0, 0) * Time.deltaTime * 2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            offsetCamera += new Vector3(1f, 0, 0) * Time.deltaTime * 2;
        }
    }
}
