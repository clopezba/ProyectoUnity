using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para la generación de enemigos - coronavirus
 */
public class GeneradorCoronavirus : MonoBehaviour
{
    public GameObject coronavirus_original;
    public float probabilidadAparicion;
    public int cantidad;
    
    
    /*
     * Método que se ejecuta una vez por fotograma
     * Ejecuta el método lanzarCoronavirus
     */
    void Update()
    {
        lanzarCoronavirus();
    }
    /*
     * Método para instanciar coronavirus
     * Los genera un objeto vacío con frecuencia aleatoria y se puede elegir la cantidad que habrá a la vez en pantalla
     */
    private void lanzarCoronavirus()
    {
        float random = Random.Range(0.0f, 200.0f);
       
        if (random < probabilidadAparicion)
        {
            if(GameObject.FindGameObjectsWithTag("Coronavirus").Length < cantidad)
            {
                Instantiate(coronavirus_original, transform.position, transform.rotation); //Saldrá el objeto en la posición y rotación del generador
            }
            
        }
    }
    
}
