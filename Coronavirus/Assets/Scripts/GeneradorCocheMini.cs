using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorCocheMini : MonoBehaviour
{
    public GameObject coche;
    public float probabilidadAparicion;
    public int cantidad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lanzarCocheMini();
    }
    private void lanzarCocheMini()
    {
        float random = Random.Range(0.0f, 500.0f); //Número aleatorio entre 0 y 100

        if (random < probabilidadAparicion)
        {
            if (GameObject.FindGameObjectsWithTag("Coche").Length < cantidad)
            {
                Instantiate(coche, transform.position, transform.rotation); //Saldrá el objeto en la posición y rotación del generador
            }
                
        }
    }
}
