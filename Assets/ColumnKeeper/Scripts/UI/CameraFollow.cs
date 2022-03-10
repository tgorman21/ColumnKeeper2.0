using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private void Update()
    {
        transform.rotation = cam.rotation;
    }
}
