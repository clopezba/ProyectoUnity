using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float fuerza;
    bool saltando;
    public int vidas;
    private int mascarillas;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        saltando = false;
        mascarillas = 0;
    }

    // Update is called once per frame
    void Update() 
    { 
            
    }
    void FixedUpdate()
    {
        //Mover a izquierda y derecha
        if (Input.GetKey(KeyCode.RightArrow) ||Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0.1f, 0.0f));
            GetComponent<SpriteRenderer>().flipX = false;
            //TODO - Animación correr
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.1f, 0.0f));
            GetComponent<SpriteRenderer>().flipX = true;
            //TODO - Animación correr
        }

        //Saltar
        if (Input.GetButton("Jump") && saltando == false)
        {
            //TODO - Animación salto
            rb2D.AddForce(transform.up * fuerza, ForceMode2D.Impulse);
            saltando = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Saltar solo cuando toque suelo
        //TODO - Valorar doble salto
        if(col.gameObject.tag == "Suelo")
        {
            saltando = false;
        }

        //Choque con Coronavirus - Menos vidas - Muerte
        if(col.gameObject.tag == "Coronavirus")
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);

            vidas--;
            Debug.Log("Te quedan " + vidas + " vidas.");
            if(vidas <= 0)
            {
                //TODO - Animación muerte
                gameObject.SetActive(false);
                Destroy(gameObject, 0.5f);
                Debug.Log("¡Game over!");

                //Comprobar y guardar nuevos records
                int recordUltimo = PlayerPrefs.GetInt("Mascarillas"); //PlayerPrefs guarda preferencias entre partidas
                if (PlayerPrefs.HasKey("Mascarillas") == false)
                {
                    //No hay record guardado
                    PlayerPrefs.SetInt("Mascarillas", mascarillas);
                    Debug.Log("¡NUEVO RECORD! " + mascarillas + " mascarillas recogidas");
                    //TODO - Pantalla de nuevo record
                }
                else
                {
                    //Sí hay record guardado
                    if(recordUltimo < mascarillas)
                    {
                        //Nuevo record
                        PlayerPrefs.SetInt("Mascarillas", mascarillas);
                        Debug.Log("¡NUEVO RECORD! " + mascarillas + " mascarillas recogidas");
                    }
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Choque con mascarillas - Recolectar
        if(col.gameObject.tag == "Mascarilla")
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
            mascarillas++;
            Debug.Log("Mascarillas: " + mascarillas);
        }
    }

}
