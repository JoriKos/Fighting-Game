using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventInt : UnityEvent<int, GameObject>
{

}

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private Stats statistics, playerStats;
    [SerializeField] private GameManager manager;
    [SerializeField] private UnityEventInt damageTakenEvent;

    private void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        statistics = playerStats.GetComponent<Stats>();
    }

    private void Update()
    {
        Debug.Log(statistics.GetHealth());
        if (statistics.GetHealth() < 0) //If health = 0, die
        {
            manager.Kill(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //If entering player hitbox, take damage
    {
        if (collision.name == "Player")
        {
            damageTakenEvent.Invoke(playerStats.GetDamage(), playerStats.gameObject);
        }
    }
}
