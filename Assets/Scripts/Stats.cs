using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int damage, health;

    public int GetDamage()
    {
        return damage;
    }
    
    public int GetHealth()
    {
        return health;
    }
}
