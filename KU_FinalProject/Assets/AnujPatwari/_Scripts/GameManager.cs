using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Color dayColor;
    public Color nightColor;
    public float duration;

    [SerializeField] GameObject fruit;

    //Game Timer
    public Text gameTimerText;
    [HideInInspector] public float gameTimer = 0f;
    [HideInInspector] public int minutes, hours, days;
    TreeScript ts;

    // Start is called before the first frame update
    void Start()
    {
        ts = FindObjectOfType<TreeScript>();
        dayColor = new Color(128 / 255f, 128 / 255f, 128 / 255f);
        nightColor = new Color(0f, 37 / 255f, 1f);
        RenderSettings.skybox.SetColor("_TintColor", nightColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (hours >= 6 && hours < 18)
        {
            RenderSettings.skybox.SetColor("_TintColor", Color.Lerp(RenderSettings.skybox.GetColor("_TintColor"), dayColor, 0.001f));
            print("Get up");
        }
        else if (hours >= 18)
        {
            RenderSettings.skybox.SetColor("_TintColor", Color.Lerp(RenderSettings.skybox.GetColor("_TintColor"), nightColor, 0.001f));
            print("Sleep");
        }
        

        #region Game Timer
        gameTimer += Time.deltaTime * 1000;
        
        minutes = (int)(gameTimer / 60) % 60;
        hours = (int)(gameTimer / 3600) % 24;
        days = (int)(gameTimer / 86400) % 365;

        string timerString = string.Format("Day {0:00} Time: {1:00}:{2:00}", days, hours, minutes);

        gameTimerText.text = timerString;

        #endregion
    }
}
