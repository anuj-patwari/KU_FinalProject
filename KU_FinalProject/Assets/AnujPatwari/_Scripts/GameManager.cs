using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject fruit;
    [SerializeField] int everyHowManyDays;
    float counter;

    //Game Timer
    public Text gameTimerText;
    public float gameTimer = 0f;
    public int minutes, hours, days;
    TreeScript ts;

    // Start is called before the first frame update
    void Start()
    {
        ts = FindObjectOfType<TreeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

        }

        #region Game Timer
        gameTimer += Time.deltaTime * 10000;

        //int seconds = (int)(gameTimer % 60);
        minutes = (int)(gameTimer / 60) % 60;
        hours = (int)(gameTimer / 3600) % 24;
        days = (int)(gameTimer / 86400) % 365;

        string timerString = string.Format("Day {0:00} Time: {1:00}:{2:00}", days, hours, minutes);

        gameTimerText.text = timerString;

        #endregion
    }
}
