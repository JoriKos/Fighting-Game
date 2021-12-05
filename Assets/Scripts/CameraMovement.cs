using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minBoundaryX, maxBoundaryX, minBoundaryY, maxBoundaryY;

    private void Update()
    {
        //Clamps camera between set X and Y positions
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minBoundaryX, maxBoundaryX),
                Mathf.Clamp(transform.position.y, minBoundaryY, maxBoundaryY),
                transform.position.z
            );
    }
}
