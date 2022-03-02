using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para generar coches, crea un Prefab de coche desde un objeto vac�o situado fuera de la c�mara
 */
public class GeneradorCoche : MonoBehaviour
{
    public GameObject coche;
    public float probabilidadAparicion;
    public int cantidad;
    
    
    /*
     * M�todo que se ejecuta en cada fotograma, si MonoBehaviour est� activo
     * Ejecuta el m�todo lanzar coche
     */
    void Update()
    {
        lanzarCoche();
    }

    /*
     * M�todo que instancia objetos coche de forma aleatoria. 
     * Se puede establecer la probabilidad de aparici�n y la cantidad de coches que puede haber activos a la vez
     */
    private void lanzarCoche()
    {
        float random = Random.Range(0.0f, 500.0f); //N�mero aleatorio entre 0 y 100

        if (random < probabilidadAparicion)
        {
            if (GameObject.FindGameObjectsWithTag("Coche").Length < cantidad)
            {
                Instantiate(coche, transform.position, transform.rotation); //Saldr� el objeto en la posici�n y rotaci�n del generador
            }
                
        }
    }
}
