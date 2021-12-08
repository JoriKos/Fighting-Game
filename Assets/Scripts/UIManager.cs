using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform playerHealthBar, enemyHealthBar; //Used to deplete bar
    [SerializeField] private Stats playerStats, enemyStats;
    private Vector2 barReduction;
    private float currentWidth;

    private void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        enemyStats = GameObject.Find("Enemy").GetComponent<Stats>();
        playerHealthBar = GameObject.Find("PlayerFill").GetComponent<RectTransform>(); //Every 1 HP damage taken = 9,4 added to the health bar sprite transform.right for player
        enemyHealthBar = GameObject.Find("EnemyFill").GetComponent<RectTransform>(); //Every 1 HP damage taken = 9,4 added to the health bar sprite transform.left for player
    }
    public void TakeDamage(int damageTaken, GameObject gameObjectToDamage)
    {
        barReduction.x = ((float) damageTaken * 9.4f);
        
        if (gameObjectToDamage == playerStats.gameObject) //Player
        {
            currentWidth = playerHealthBar.sizeDelta.x;
            //playerHealthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentWidth -= barReduction.x); This don't work!!!!!!
            playerHealthBar.sizeDelta -= barReduction;
        }
        
        if (gameObjectToDamage == enemyStats.gameObject) //Enemy
        {
            currentWidth = enemyHealthBar.sizeDelta.x;
            enemyHealthBar.sizeDelta -= barReduction;
        }
    }
}