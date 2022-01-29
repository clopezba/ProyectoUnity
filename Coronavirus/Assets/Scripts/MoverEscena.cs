using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEscena : MonoBehaviour
{
    public float tamanyoEscena;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distancia = mainCamera.transform.position - transform.position;
        if (tamanyoEscena < distancia.magnitude)
        {
            transform.position = new Vector3(mainCamera.transform.position.x + 20.0f, transform.position.y, transform.position.z);
        }
    }
}
