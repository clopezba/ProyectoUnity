using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para generar coches, crea un Prefab de coche desde un objeto vacío situado fuera de la cámara
 */
public class GeneradorCoche : MonoBehaviour
{
    public GameObject coche;
    public float probabilidadAparicion;
    public int cantidad;
    
    
    /*
     * Método que se ejecuta en cada fotograma, si MonoBehaviour está activo
     * Ejecuta el método lanzar coche
     */
    void Update()
    {
        lanzarCoche();
    }

    /*
     * Método que instancia objetos coche de forma aleatoria. 
     * Se puede establecer la probabilidad de aparición y la cantidad de coches que puede haber activos a la vez
     */
    private void lanzarCoche()
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
