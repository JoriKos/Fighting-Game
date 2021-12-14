using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int damage, health;

    private void Update()
    {
        Debug.Log(health);
    }

    public int GetDamage()
    {
        return damage;
    }
    
    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int damageTaken, GameObject uselessObject)
    {
        this.health -= damageTaken;
    }
    
}
