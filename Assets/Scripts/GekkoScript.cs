using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GekkoScript : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _camera.transform.eulerAngles = new Vector3(21.85f, -1.3f, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        var layer = other.collider.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Environment") || layer == LayerMask.NameToLayer("Enemy"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}