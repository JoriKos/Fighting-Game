using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //State machine. States: Attack, approach, retreat
    [SerializeField] private float timer, timer2, stateTimer, stateDuration, attackCooldown, attackDuration, playerX, movementSpeed;
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
        state = 1;
    }

    private void Update()
    {
        playerX = player.transform.position.x;
        Debug.Log(Vector2.Distance(new Vector2(playerX, 0), new Vector2(this.transform.position.x, 0)));

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
        if (canAttack)
        {
            attackCollider.enabled = true;
            timerStart = true;
            canAttack = false;
        }
        state = 2;
    }

    private void Approach()
    {
        if (Vector2.Distance(new Vector2(playerX, 0), new Vector2(this.transform.position.x, 0)) > 6.9f)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
        else
        {
            state = 0;
        }
    }
    
    private void Retreat()
    {
        if (Vector2.Distance(new Vector2(playerX, 0), new Vector2(this.transform.position.x, 0)) > 7f || Vector2.Distance(new Vector2(playerX, 0), new Vector2(this.transform.position.x, 0)) < 18f)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            if (Vector2.Distance(new Vector2(playerX, 0), new Vector2(this.transform.position.x, 0)) > 18f)
            {
                state = 1;
            }
        }
        else
        {
            state = 1;
        }
    }
}