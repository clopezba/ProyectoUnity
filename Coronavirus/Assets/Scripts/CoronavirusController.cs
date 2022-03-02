using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para el controlador de coronavirus
 */
public class CoronavirusController : MonoBehaviour
{
    /*
     * Método que se ejecuta una vez por fotograma en un tiempo fijo
     * Aplica una fuerza que determina la dirección y velocidad de los virus
     */
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-12.0f*Time.deltaTime, 0.0f), ForceMode2D.Impulse);
    }

    /*
     * Método que gestiona las colisiones con otros objetos
     * Si el choque es con un coche, la colisión será ignorada
     * Si es con un destructor de objetos, se destruirá el coronavirus
     */
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Coche")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        if(col.gameObject.tag == "Destructor")
        {
            Destroy(gameObject);
        }
    }

    


}
