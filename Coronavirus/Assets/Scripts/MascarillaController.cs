using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para el controlador de mascarillas
 */
public class MascarillaController : MonoBehaviour
{
    /*
     * M�todo que se ejecuta una vez por fotograma en un tiempo fijo
     * A�ade una fuerza que establece la direcci�n y velocidad de las mascarillas
     * Destruye el objeto cuando sale de la c�mara
     */
    void FixedUpdate()
    {
        //Movimiento mascarillas
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
        Destroy(gameObject, 10.0f);
    }

}
