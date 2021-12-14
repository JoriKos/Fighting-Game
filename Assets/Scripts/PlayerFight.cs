using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] private float timer, timer2, attackCooldown, attackDuration;
    private CapsuleCollider2D attackCollider;
    private bool canAttack, timerStart;

    private void Awake()
    {
        attackCollider = GetComponentInChildren<CapsuleCollider2D>();
        attackCollider.enabled = false;
        canAttack = true;
    }

    private void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime;
        }

        if (!canAttack)
        {
            timer2 += Time.deltaTime;
        }

        if (timer > attackDuration)
        {
            attackCollider.enabled = false;
            timerStart = false;
            timer = 0;
        }

        if (timer2 > attackCooldown)
        {
            canAttack = true;
            timer2 = 0;
        }

        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            Attack();
            canAttack = false;
        }
    }


    private void Attack()
    {
        attackCollider.enabled = true;
        timerStart = true;
    }
}
