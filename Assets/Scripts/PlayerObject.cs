using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private int health, damage;
    [SerializeField] private GameManager manager;
    [SerializeField] private EnemyObject enemy;

    private void Awake()
    {
        enemy = GameObject.Find("Enemy").GetComponent<EnemyObject>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            manager.Kill(this.gameObject);
        }
    }

    public int GetHealth()
    {
        return health;
    }
    public int GetDamage()
    {
        return damage;
    }

    public void TakeDamage(int tempHealth)
    {
        health -= tempHealth;
    }
}