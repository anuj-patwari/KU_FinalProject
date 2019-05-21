using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject fruit;

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
    }

    private void OnMouseDown()
    {
        
    }
}
