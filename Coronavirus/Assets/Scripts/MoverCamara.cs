using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mover la c�mara
        transform.Translate(new Vector3(0.1f*Time.deltaTime, 0.0f));
    }
}
