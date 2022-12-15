using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private Transform gekkon;

    [SerializeField] private float speed = 1f;

    private Camera _camera;

    private void Update()
    {
        if (Vector3.Distance(gekkon.transform.position, transform.position) > 4)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1f) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, 1f) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(1f, 0, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * speed;
        }
    }
}
