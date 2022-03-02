using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para el controlador de los coches
 */
public class CocheController : MonoBehaviour
{
    /*
     * Método que se ejecuta en cada fotograma de velocidad fija
     * Establece la dirección y velocidad en que se mueven los coches
     */
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f*Time.deltaTime, 0.0f);
    }
    
    /*
     * Método que gestiona las colisiones con otros objetos
     * Si choca contra el destructor de objetos (al salir de la cámara), se destruye el coche
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destructor")
        {
            Destroy(gameObject);
        }
    }
   



}
