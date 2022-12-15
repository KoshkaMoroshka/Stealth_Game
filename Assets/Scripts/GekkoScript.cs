using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GekkoScript : MonoBehaviour
{
    [SerializeField] private Vector3 offsetCamera;
    [SerializeField] private float radius = 0.4f;
    [SerializeField] private float angularSpeed = 4f;

    private float _angle = 0f;
    private Camera _camera;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _camera.transform.position = transform.position + offsetCamera;
        _camera.transform.LookAt(transform);

        var positionX = transform.position.x + Mathf.Cos(_angle) * radius;
        var positionZ = transform.position.z + Mathf.Sin(_angle) * radius;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            offsetCamera = (new Vector3(positionX, 0, positionZ) * Time.deltaTime) + offsetCamera;
            _angle += Time.deltaTime * angularSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            offsetCamera = -(new Vector3(positionX, 0, positionZ) * Time.deltaTime) + offsetCamera;
            _angle -= Time.deltaTime * angularSpeed;
        }

        if (_angle > 360 || _angle < -360)
        {
            _angle = 0;
        }
    }
}
