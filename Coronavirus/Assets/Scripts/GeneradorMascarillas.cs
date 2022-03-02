using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para la generaci�n de mascarillas
 */
public class GeneradorMascarillas : MonoBehaviour
{
    public GameObject mascarilla_original;
    public float probabilidadAparicion;
    public int cantidad;

    /*
     * M�todo que se ejecuta una vez por fotograma
     * Ejecuta el m�todo lanzarObjeto
     */
    void Update()
    {
        lanzarObjeto();
    }

    /*
     * M�todo que instancia mascarillas con una frecuencia aleatoria
     * Permite seleccionar la cantidad de mascarillas que puede haber en pantalla a la vez
     */
    private void lanzarObjeto()
    {
        float random = Random.Range(0.0f, 200.0f); //N�mero aleatorio entre 0 y 100
        if (random < probabilidadAparicion)
        {
            if (GameObject.FindGameObjectsWithTag("Mascarilla").Length < cantidad)
            {
                 Instantiate(mascarilla_original, transform.position, transform.rotation); //Saldr� el objeto en la posici�n y rotaci�n del generador
            }
               
        }
    }
    
}
