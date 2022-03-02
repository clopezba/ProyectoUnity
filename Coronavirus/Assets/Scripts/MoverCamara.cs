using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para el movimiento de la c�mara de la escena de juego
 */
public class MoverCamara : MonoBehaviour
{
   /*
    * M�todo que se ejecuta una vez por fotograma
    * Establece la direcci�n y velocidad de la c�mara de la escena de juego
    */
    void Update()
    {
       transform.Translate(new Vector3(0.1f*Time.deltaTime, 0.0f));
    }
}
