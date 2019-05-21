using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3 (Random.Range(-400f, 400f), Random.Range (300f, 700f), Random.Range(-400f, 400f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
