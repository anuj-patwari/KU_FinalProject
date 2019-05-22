using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    GameManager gm;
    [SerializeField] GameObject fruit;
    public int everyHowManyDays = 3;
    [SerializeField]float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.days % everyHowManyDays == 0 && gm.days != 0)
        {
            counter++;

            if (counter < 3000)
            {

            }
            if (counter == 2750)
            {
                Happen();
            }
            if (counter == 2800)
            {
                Happen();
            }
            if (counter == 2850)
            {
                Happen();
            }
            if (counter == 2900)
            {
                Happen();
            }
            if (counter == 2950)
            {
                Happen();
            }
            if (counter == 3000)
            {
                Happen();
            }

        }

        else if (gm.days %everyHowManyDays != 0)
        {
            counter = 0;
        }
    }

    public void Happen()
    {
        Instantiate(fruit, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z), gameObject.transform.rotation);
    }
}
