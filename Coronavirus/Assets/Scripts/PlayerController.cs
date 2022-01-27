using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal >= -1 && horizontal <= 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.1f * horizontal, 0), ForceMode2D.Impulse); //Añadir fuerza para que se desplace a los lados
           // gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.forward * 200f; //Aplicar velocidad específica al player
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
        }
            
            
        
    }

    

}
