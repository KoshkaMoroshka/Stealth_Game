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

        parent.position = Vector3.Lerp(transform.position, parent.position, Time.deltaTime * (speed/1000));
        parent.LookAt(target.transform);
    }

    public static bool IsVisible(Transform eye, GameObject target, float angle)
    {
        var direction = (target.transform.position - eye.position).normalized;
        if (Vector3.Dot(direction, eye.TransformDirection(Vector3.forward)) < angle)
            return false;

        Physics.Raycast(new Ray(eye.position, direction), out RaycastHit hit, 1000f);

        if (hit.collider == null)
            return false;

        return hit.collider.gameObject == target;
    }
}
