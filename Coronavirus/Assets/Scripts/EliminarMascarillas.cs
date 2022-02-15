using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarMascarillas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Elimina las mascarillas cuando salen de la cámara
        Destroy(gameObject, 10.5f);
    }
}
