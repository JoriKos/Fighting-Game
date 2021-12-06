using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Stats statistics;
    [SerializeField] private PlayerFight player;
    [SerializeField] private GameManager manager;
    [SerializeField] private int health;

    private void Awake()
    {
        statistics = GameObject.Find("Player").GetComponent<Stats>();
        player = GameObject.Find("Player").GetComponent<PlayerFight>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        health = statistics.GetHealth();
        if (health < 0)
        {
            manager.Kill(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            health -= player.GetDamage();
        }
    }
}
