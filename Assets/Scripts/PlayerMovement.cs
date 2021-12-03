using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed, jumpHeight, timer;
    private bool canJump;

    private void Awake()
    {
        canJump = true;
    }

    private void Update()
    {
        if (!canJump)
        {
            timer += Time.deltaTime;
        }

        if (timer > 0.75f)
        {
            canJump = true;
            timer = 0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        if (canJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
                canJump = false;
            }
        }
    }
}
