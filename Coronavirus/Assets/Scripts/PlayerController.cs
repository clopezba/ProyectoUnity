using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Animator animator;
    public float fuerza;
    private bool saltando;
    private int vidas;

    public AudioClip salto_clip;
    public AudioClip danyo_clip;
    public AudioClip coche_clip;
    public AudioClip mascarilla_clip;
    public AudioClip muerte_clip;
    public AudioClip alcantarilla_clip;

    private AudioSource personajeAS;

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
        PlayerPrefs.DeleteKey("Record");
    }
    // Start is called before the first frame update
    void Start()
    {
        saltando = false;
        vidas = 3;
        mascarillas = 0;
        personajeAS = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        animator.SetBool("Corriendo", false);
        animator.SetBool("Saltando", saltando);
        //animator.SetBool("Cayendo", false);


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
            personajeAS.PlayOneShot(salto_clip);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Saltar solo cuando toque suelo
        //TODO - Valorar doble salto
        if(col.gameObject.tag == "Suelo" || col.gameObject.tag == "Coche")
        {
            saltando = false;
        }
        //Choque con Coronavirus - Menos vidas - Muerte
        if (col.gameObject.tag == "Coronavirus")
        {
            personajeAS.PlayOneShot(danyo_clip);
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
            danyo();
        }
        if (col.gameObject.tag == "Alcantarilla") { 
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        
        }
        }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Choque con mascarillas - Recolectar
        if(col.gameObject.tag == "Mascarilla")
        {
            personajeAS.PlayOneShot(mascarilla_clip);
            Destroy(col.gameObject);
            mascarillas++;
            Debug.Log("Mascarillas: " + mascarillas);
        }
        //Choque con coche
        if (col.gameObject.tag == "Choque")
        {
            personajeAS.PlayOneShot(coche_clip);
            danyo();
            StartCoroutine(choqueCoche());
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alcantarilla")
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        {
            if (GetComponent<SpriteRenderer>().transform.position.y <= -4.5)
            {

                personajeAS.PlayOneShot(alcantarilla_clip);
            }
        }
    }
    void OnBecameInvisible()
    {
        danyo();
        StartCoroutine(Muerte());
    }
    
    private void danyo()
    {
        vidas--;
        Debug.Log("Te quedan " + vidas + " vidas.");
        if (vidas <= 0)
        {
            personajeAS.PlayOneShot(muerte_clip);
            animator.SetTrigger("Daño");
            StartCoroutine(Muerte());
            Debug.Log("¡Game over!");
            
            //Comprobar y guardar nuevos records
            int recordUltimo = PlayerPrefs.GetInt("Mascarillas"); //PlayerPrefs guarda preferencias entre partidas
            if (PlayerPrefs.HasKey("Mascarillas") == false)
            {
                //No hay record guardado
                PlayerPrefs.SetInt("Mascarillas", mascarillas);
                Debug.Log("¡NUEVO RECORD! " + mascarillas + " mascarillas recogidas");
                PlayerPrefs.SetString("Record", "Nuevo record");
            }
            else
            {
                //Sí hay record guardado
                if (recordUltimo < mascarillas)
                {
                    //Nuevo record
                    PlayerPrefs.SetInt("Mascarillas", mascarillas);
                    Debug.Log("¡NUEVO RECORD! " + mascarillas + " mascarillas recogidas");
                    PlayerPrefs.SetString("Record", "Nuevo record");
                }
            }
        }
        else
        {
                 StartCoroutine(Parpadeo());               
        }
        GuardarDatos();
    }
    IEnumerator choqueCoche()
    {
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GameObject.FindWithTag("Coche").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    void GuardarDatos()
    {
        PlayerPrefs.SetInt("Mascarillas_actuales", mascarillas);
    }

    private IEnumerator Parpadeo()
    {
        SpriteRenderer jugadorRender = GetComponent<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            jugadorRender.color = new Color(0, 0, 0, 18);
            yield return new WaitForSeconds(0.08f);
            jugadorRender.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator Muerte()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("GameOver");
    }
}
