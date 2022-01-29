using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEscena : MonoBehaviour
{
    public float tamanyoEscena;
    private Camera camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main; //Selecciona la cámara principal
    }

    // Update is called once per frame
    void Update()
    {
        if(tamanyoEscena <= (camara.transform.position - transform.position).magnitude) //Calcula distancia entre escena y cámara para repetir la escena si es necesario
        {
            transform.position = new Vector3(camara.transform.position.x, transform.position.y);
        }
    }
}
