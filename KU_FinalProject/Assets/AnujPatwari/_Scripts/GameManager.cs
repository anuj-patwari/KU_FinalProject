using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject fruit;

    //Game Timer
    public Text gameTimerText;
    float gameTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(fruit, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z), gameObject.transform.rotation);
        }

        #region Game Timer
        gameTimer += Time.deltaTime * 100;

        //int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;
        int days = (int)(gameTimer / 86400) % 365;

        string timerString = string.Format("Day {0:00} Time: {1:00}:{2:00}", days, hours, minutes);

        gameTimerText.text = timerString;

        #endregion
    }
}
