using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        CameraFollow();
    }

    // Update is called once per frame
    void CameraFollow()
    {
        transform.position = _car.transform.position + offset;
    }
}
