using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed, jumpHeight, timer;
    private bool canJump;
    private Rigidbody2D rb;

    private void Awake()
    {
        canJump = true;
        rb = GetComponent<Rigidbody2D>();
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
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        if (canJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpHeight);
                canJump = false;
            }
        }
    }
}
