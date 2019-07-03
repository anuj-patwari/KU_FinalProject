using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    //Day and Night cycle variables
    public Color dayColor;
    public Color nightColor;
    public float duration;
    public GameObject sun;
    public GameObject moon;

    [Range(1, 45)]
    [Tooltip("This is meant for testing only!")]
    public int gameSpeed = 1;

    [SerializeField] GameObject fruit;

    //Game Timer
    public Text gameTimerText;
    [HideInInspector] public float gameTimer = 0f;
    [HideInInspector] public int minutes, hours, days;
    TreeScript ts;

    //Characeter Switching
    [SerializeField] GameObject[] Characters;
    [Tooltip("Key to Give Character Control")]
    [SerializeField] KeyCode[] characterKeys;
    [SerializeField] RawImage[] characterIndicators;
    [Tooltip("Ignores Character Control Keys. Uses first Key of characterKeys for now")]
    [SerializeField] bool shouldCycle;
    int currentCharacterID;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = 45;
        ts = FindObjectOfType<TreeScript>();
        dayColor = new Color(128 / 255f, 128 / 255f, 128 / 255f);
        nightColor = new Color(0f, 37 / 255f, 1f);
        RenderSettings.skybox.SetColor("_TintColor", dayColor);
        gameTimer = 48600f;                 //Setting the time to 1 PM at start

        SwitchCharacter(0);
    }

    // Update is called once per frame
    void Update()
    {

        #region Day and Night cycle - Sky color change & Sun & Moon revolving
        if (hours >= 6 && hours < 18)
        {
            RenderSettings.skybox.SetColor("_TintColor", Color.Lerp(RenderSettings.skybox.GetColor("_TintColor"), dayColor, 0.001f));
        }
        else if (hours >= 18)
        {
            RenderSettings.skybox.SetColor("_TintColor", Color.Lerp(RenderSettings.skybox.GetColor("_TintColor"), nightColor, 0.001f));
        }

        sun.transform.RotateAround(new Vector3(0, 0, -32), Vector3.right, Time.deltaTime * 0.413f);
        sun.transform.LookAt(new Vector3(0, 0, -32));
        moon.transform.RotateAround(new Vector3(0, 0, -32), Vector3.right, Time.deltaTime * 0.413f);
        moon.transform.LookAt(new Vector3(0, 0, -32));

        Time.timeScale = gameSpeed;
        #endregion

        #region Game Timer
        gameTimer += Time.deltaTime * 100;
        
        minutes = (int)(gameTimer / 60) % 60;
        hours = (int)(gameTimer / 3600) % 24;
        days = (int)(gameTimer / 86400) % 365;

        string timerString = string.Format("Day {0:00} Time: {1:00}:{2:00}", days, hours, minutes);

        gameTimerText.text = timerString;

        #endregion

        //Probably need to optimise to use delegates
        #region Character Switch Input Check
        if (shouldCycle)
        {
            if (Input.GetKeyDown(characterKeys[0]))
            {
                currentCharacterID += 1;
                SwitchCharacter(currentCharacterID);

            }


        }
        else
        {
            foreach (KeyCode keycode in characterKeys)
            {
                if (Input.GetKeyDown(keycode))
                {
                    SwitchCharacter(System.Array.IndexOf(characterKeys, keycode));
                }
            }
        }

        #endregion
    }

    private void FixedUpdate()
    {
        //transform.LookAt(new Vector3(targetPos.x, 0f, targetPos.z));
    }


    void SwitchCharacter(int position)
    {
       
        foreach (GameObject character in Characters)
        {
            character.GetComponent<FirstPersonController>().enabled = false;

        }
        foreach (RawImage indicator in characterIndicators)
        {
            indicator.color = Color.white;
        }
        Characters[position].GetComponent<FirstPersonController>().enabled = true;

        characterIndicators[position].color = Color.green;
        if (currentCharacterID >= (Characters.Length - 1))
        {
            currentCharacterID = -1;
        }
    }
}
