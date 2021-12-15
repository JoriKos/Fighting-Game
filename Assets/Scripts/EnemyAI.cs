using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //State machine. States: Attack, approach, retreat
    [SerializeField] private float timer, timer2, stateTimer, stateDuration, attackCooldown, attackDuration, playerX;
    private GameObject player;
    private CapsuleCollider2D attackCollider;
    private bool canAttack, timerStart;
    private int state;

    private void Awake()
    {
        player = GameObject.Find("Player");
        attackCollider = GetComponentInChildren<CapsuleCollider2D>();
        attackCollider.enabled = false;
        canAttack = true;
        state = -1;
    }

    private void Update()
    {
        playerX = player.transform.position.x;

        #region State duration
        stateTimer += Time.deltaTime;
        #endregion

        #region Attack duration
        if (timerStart)
        {
            timer += Time.deltaTime;
        }

        if (timer > attackDuration)
        {
            attackCollider.enabled = false;
            timerStart = false;
            timer = 0;
        }
        #endregion

        #region Attack cooldown
        if (!canAttack)
        {
            timer2 += Time.deltaTime;
        }

        if (timer2 > attackCooldown)
        {
            canAttack = true;
            timer2 = 0;
        }
        #endregion

        switch (state)
        {
            case 0:
                Attack();
                break;
            case 1:
                Approach();
                break;
            case 2:
                Retreat();
                break;
        }
    }


    private void Attack()
    {
        attackCollider.enabled = true;
        timerStart = true;
    }

    private void Approach()
    {
        if (playerX + this.transform.position.x > 5)
        {
            transform.Translate(Vector2.left);
        }
        else
        {
            state = 0;
        }
    }
    
    private void Retreat()
    {

    }
}