using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float fuerza;
    bool saltando;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        saltando = false;
    }

    // Update is called once per frame
    void Update() 
    { 
            
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) ||Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0.1f, 0.0f));
            GetComponent<SpriteRenderer>().flipX = false;
            //TODO - Animación correr
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.1f, 0.0f));
            GetComponent<SpriteRenderer>().flipX = true;
            //TODO - Animación correr
        }
        if (Input.GetButton("Jump") && saltando == false)
        {
            //TODO - Animación salto
            rb2D.AddForce(transform.up * fuerza, ForceMode2D.Impulse);
            saltando = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Suelo")
        {
            saltando = false;
        }
        if(col.gameObject.tag == "Coronavirus")
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
            
            //TODO - Animación muerte
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }

}
