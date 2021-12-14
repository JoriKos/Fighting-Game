using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private int health, damage;
    [SerializeField] private GameManager manager;
    [SerializeField] private PlayerObject player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerObject>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (health <= 0) //If health = 0, die
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
