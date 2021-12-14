using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    [SerializeField] private PlayerObject player;
    [SerializeField] private EnemyObject enemy;
    [SerializeField] private UIManager manager;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerObject>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyObject>();
        manager = GameObject.Find("Manager").GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Enemy")
        {
            enemy.TakeDamage(player.GetDamage());
            manager.TakeDamage(player.GetDamage(), player.gameObject);
        }
        
        if(collision.tag == "Player")
        {
            player.TakeDamage(enemy.GetDamage());
            manager.TakeDamage(enemy.GetDamage(), enemy.gameObject);
        }
    }
}
