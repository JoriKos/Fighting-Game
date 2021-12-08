using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private Stats statistics, enemyStats;
    [SerializeField] private GameManager manager;
    [SerializeField] private UnityEventInt damageTakenEvent;

    private void Awake()
    {
        enemyStats = GameObject.Find("Enemy").GetComponent<Stats>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        statistics = enemyStats.GetComponent<Stats>();
    }

    private void Update()
    {
        if (statistics.GetHealth() <= 0) //If health = 0, die
        {
            manager.Kill(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //If entering player hitbox, take damage
    {
        if (collision.name == "Enemy")
        {
            damageTakenEvent.Invoke(enemyStats  .GetDamage(), this.gameObject);
        }
    }
}