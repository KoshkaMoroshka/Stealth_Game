using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform rightEye;
    [SerializeField] private Transform leftEye;
    [SerializeField] private GameObject target;

    [SerializeField] private float angle = 0.5f;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        var flag = false;

        flag |= IsVisible(rightEye, target, angle);
        flag |= IsVisible(leftEye, target, angle);

        if (!flag)
            return;

        var parent = transform.parent.transform;

        parent.position += (target.transform.position - parent.position).normalized * speed * Time.deltaTime;
        parent.LookAt(target.transform);
    }

    public static bool IsVisible(Transform eye, GameObject target, float angle)
    {
        var offset = new Vector3(0, 0.25f, 0);
        var direction = (target.transform.position + offset - eye.position).normalized;
        if (Vector3.Dot(direction, eye.TransformDirection(Vector3.forward)) < angle)
            return false;

        Physics.Raycast(new Ray(eye.position, direction), out RaycastHit hit, 10f);

        if (hit.collider == null)
            return false;

        if (hit.collider.gameObject != target)
            return false;

        Debug.DrawLine(eye.position, target.transform.position + offset);
        return true;
    }
}
