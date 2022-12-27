using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private Transform gekkon;

    [SerializeField] private Transform aim;

    [SerializeField] private float speed = 1f;

    private RaycastHit _hit;

    private void Update()
    {
        if (Vector3.Distance(gekkon.transform.position, transform.position) > 4)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 30, 0) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 30, 0) * Time.deltaTime * speed);
        }

        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                _hit = hit;
        }

        aim.transform.position = Vector3.Lerp(aim.transform.position, _hit.point, Time.deltaTime * speed);
        aim.rotation = transform.rotation;
            
    }
}
