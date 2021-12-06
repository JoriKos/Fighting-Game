using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int victoryScreenTime;
    private float timer;
    private bool timerStart;

    private void Awake()
    {
        timerStart = false;
        timer = 0;
    }

    private void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime;
        }

        if (timer > victoryScreenTime)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Kill(GameObject loser)
    {
        Destroy(loser);
    }

    public void Win()
    {
        //UI win
        timerStart = true;
    }
}
