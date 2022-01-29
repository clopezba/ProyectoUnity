using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorCoronavirus : MonoBehaviour
{
    public GameObject coronavirus_original;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lanzarCoronavirus();
    }
    private void lanzarCoronavirus()
    {
        float random = Random.Range(0.0f, 200.0f); //Número aleatorio entre 0 y 100
        if(random < 0.3f) 
        {
            GameObject.Instantiate(coronavirus_original, transform.position, transform.rotation); //Saldrá el coronavirus en la posición y rotación del generador
        }
    }
}
