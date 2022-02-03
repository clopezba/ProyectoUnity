using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorCoronavirus : MonoBehaviour
{
    public GameObject coronavirus_original;
    public float probabilidadAparicion;
    public int cantidad;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lanzarCoronavirus();
    }
    //Instancia los objetos, tanto Coronavirus como Mascarillas
    private void lanzarCoronavirus()
    {
        float random = Random.Range(0.0f, 200.0f); //N�mero aleatorio entre 0 y 100
       
        if (random < probabilidadAparicion)
        {
            if(GameObject.FindGameObjectsWithTag("Coronavirus").Length < cantidad)
            {
                GameObject.Instantiate(coronavirus_original, transform.position, transform.rotation); //Saldr� el objeto en la posici�n y rotaci�n del generador
            }
            
        }
    }
    
}
