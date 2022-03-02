using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para el movimiento de la cámara de la escena de juego
 */
public class MoverCamara : MonoBehaviour
{
   /*
    * Método que se ejecuta una vez por fotograma
    * Establece la dirección y velocidad de la cámara de la escena de juego
    */
    void Update()
    {
       transform.Translate(new Vector3(0.1f*Time.deltaTime, 0.0f));
    }
}
