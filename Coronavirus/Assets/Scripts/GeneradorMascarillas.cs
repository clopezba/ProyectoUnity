using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMascarillas : MonoBehaviour
{
    public GameObject mascarilla_original;
    public float probabilidadAparicion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lanzarObjeto();
    }
    //Instancia los objetos, tanto Coronavirus como Mascarillas
    private void lanzarObjeto()
    {
        float random = Random.Range(0.0f, 200.0f); //N�mero aleatorio entre 0 y 100
        if (random < probabilidadAparicion)
        {
            GameObject.Instantiate(mascarilla_original, transform.position, transform.rotation); //Saldr� el objeto en la posici�n y rotaci�n del generador
        }
    }
    
}
