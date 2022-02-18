using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronavirusController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movimiento coronavirus
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-12.0f*Time.deltaTime, 0.0f), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Coche")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
