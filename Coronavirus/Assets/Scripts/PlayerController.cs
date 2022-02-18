using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Animator animator;
    public float fuerza;
    private bool saltando;
    private int vidas;

    public int Vidas
    {
        get { return vidas; }
        set { vidas = value; }
    }

    private int mascarillas;
    public int Mascarillas
    {
        get { return mascarillas; }
        set { mascarillas = value; }
    }

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        saltando = false;
        vidas = 3;
        mascarillas = 0;
    }
    void FixedUpdate()
    {
        animator.SetBool("Corriendo", false);
        animator.SetBool("Saltando", saltando);
        animator.SetBool("Cayendo", false);


        float horizontal = Input.GetAxis("Horizontal");
        //Mover a izquierda y derecha
        if (horizontal > 0.0f)
        {
            rb2D.AddForce(new Vector2(0.5f, 0.0f), ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Corriendo", true);
        }
        else if(horizontal < 0.0f)
        {
            rb2D.AddForce(new Vector2(-0.5f, 0.0f), ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("Corriendo", true);
        }
        
        //Saltar
        if (Input.GetButton("Jump") && saltando == false)
        {
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
        if (col.gameObject.tag == "Coronavirus")
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
            danyo();
        }
        //Choque con coche
        if (col.gameObject.tag == "Coche")
        {
            if (!saltando)
            {
                danyo();
                Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            } else
            {
                saltando = false;
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
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alcantarilla")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject, 1.5f);    
    }
    void OnDestroy()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void danyo()
    {
        vidas--;
        Debug.Log("Te quedan " + vidas + " vidas.");
        if (vidas == 0)
        {
            animator.SetTrigger("Daño");
            Destroy(gameObject, 1.5f);
            Debug.Log("¡Game over!");
            SceneManager.LoadScene("GameOver");

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
                if (recordUltimo < mascarillas)
                {
                    //Nuevo record
                    PlayerPrefs.SetInt("Mascarillas", mascarillas);
                    Debug.Log("¡NUEVO RECORD! " + mascarillas + " mascarillas recogidas");
                }
            }
        }
    }
}
