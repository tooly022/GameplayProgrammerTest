using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text gameClock;
    [SerializeField] private int timeLeft = 300;
    

    void Start()
    {
        InvokeRepeating("Countdown", 1, 1);
    }

    void Update()
    {
        
        gameClock.text = ("" + timeLeft);
        if (timeLeft == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    private void Countdown()
    {
        timeLeft--;
    }

}
