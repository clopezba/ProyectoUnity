using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para la generaci�n de enemigos - coronavirus
 */
public class GeneradorCoronavirus : MonoBehaviour
{
    public GameObject coronavirus_original;
    public float probabilidadAparicion;
    public int cantidad;
    
    
    /*
     * M�todo que se ejecuta una vez por fotograma
     * Ejecuta el m�todo lanzarCoronavirus
     */
    void Update()
    {
        lanzarCoronavirus();
    }
    /*
     * M�todo para instanciar coronavirus
     * Los genera un objeto vac�o con frecuencia aleatoria y se puede elegir la cantidad que habr� a la vez en pantalla
     */
    private void lanzarCoronavirus()
    {
        float random = Random.Range(0.0f, 200.0f);
       
        if (random < probabilidadAparicion)
        {
            if(GameObject.FindGameObjectsWithTag("Coronavirus").Length < cantidad)
            {
                Instantiate(coronavirus_original, transform.position, transform.rotation); //Saldr� el objeto en la posici�n y rotaci�n del generador
            }
            
        }
    }
    
}
