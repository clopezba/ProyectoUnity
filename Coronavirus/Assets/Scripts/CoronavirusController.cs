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
        //Movimiento Coronavirus
        transform.Translate(new Vector3(-0.02f, 0.0f));
    }
}
