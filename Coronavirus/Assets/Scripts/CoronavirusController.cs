using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronavirusController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento coronavirus
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-6.5f*Time.deltaTime, 0.0f), ForceMode2D.Impulse);
    }
}
