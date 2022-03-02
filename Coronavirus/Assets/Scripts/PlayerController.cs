using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script para el controlador del jugador
 */
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Rigidbody2D jugador;
    public Animator animator;
    public float fuerza;
    private bool saltando;
    private int vidas; //variable local
    private int mascarillas; //variable local

    public AudioClip salto_clip;
    public AudioClip danyo_clip;
    public AudioClip coche_clip;
    public AudioClip mascarilla_clip;
    public AudioClip muerte_clip;
    public AudioClip alcantarilla_clip;

    private AudioSource personajeAS;

    public int Vidas //variable que puede usarse desde otro script
    {
        get { return vidas; }
        set { vidas = value; }
    }
    public int Mascarillas //variable que puede usarse desde otro script
    {
        get { return mascarillas; }
        set { mascarillas = value; }
    }

    /*
     * M�todo que se ejecuta al cargar el script
     * Asigna los componentes Rigidbody2D, Animator y AudioSource a unas variables
     * Elimina el valor almacenado que indica si se ha batido un record
     */
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        personajeAS = GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey("Record");
    }

    /*
     * M�todo que se ejecuta al comenzar la ejecuci�n del script
     * Establece los valores iniciales de vidas, mascarillas y la condici�n de saltando
     */
    void Start()
    {
        saltando = false;
        vidas = 3;
        mascarillas = 0;
        
    }
  
    /*
     * M�todo que se ejecuta una vez por fotograma en un tiempo fijo
     * A�ade las animaciones de correr y saltar
     * Establece las fuerzas (direcci�n y velocidad) que se aplicar�n al jugador seg�n las teclas pulsadas
     */
    void FixedUpdate()
    {
        animator.SetBool("Corriendo", false);
        animator.SetBool("Saltando", saltando);

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

        //Reproducir sonido al caer
        if (jugador.transform.position.y <= -4.5 && jugador.transform.position.y >= -4.8)
        {
            personajeAS.PlayOneShot(alcantarilla_clip);
        }
    }

    /*
     * M�todo que gestiona las colisiones entrantes 
     */
    void OnCollisionEnter2D(Collision2D col)
    {
        //Saltar solo cuando toque suelo
        if(col.gameObject.tag == "Suelo" || col.gameObject.tag == "Coche")
        {
            saltando = false;
        }
        //Choque con Coronavirus: reproduce sonido de da�o, inactiva y destruye al virus y ejecuta el m�todo danyo
        if (col.gameObject.tag == "Coronavirus")
        {
            personajeAS.PlayOneShot(danyo_clip);
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
            danyo();
        }
        //Cuando pasa por encima de la alcantarilla, no le afecta la colisi�n y cae al vacio
        if (col.gameObject.tag == "Alcantarilla") { 
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        //Choque con destructor de objetos: se destruye el jugador y carga la escena de GameOver
        if (col.gameObject.tag == "Destructor")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    /*
     * M�todo que gestiona las entradas a disparadores
     */
    void OnTriggerEnter2D(Collider2D col)
    {
        //Choque con mascarillas: reproduce sonido de obtenci�n de mascarillas,
        //destruye la mascarilla y a�ade una m�s a la cuenta
        if(col.gameObject.tag == "Mascarilla")
        {
            personajeAS.PlayOneShot(mascarilla_clip);
            Destroy(col.gameObject);
            mascarillas++;
        }
        //Choque con coche: reproduce sonido de da�o con coche, ejecuta el m�todo danyo e ignora la colisi�n con el coche
        if (col.gameObject.tag == "Choque")
        {
            personajeAS.PlayOneShot(coche_clip);
            danyo();
            StartCoroutine(choqueCoche());
        }
    }

    /*
     * M�todo que se ejecuta cuando el jugador desaparece de la escena
     * Ejecuta el m�todo danyo y la subrutina Muerte
     */
    void OnBecameInvisible()
    {
        danyo();
        StartCoroutine(Muerte());
    }
    
    /*
     * M�todo que se ejecuta cuando el personaje sufre un da�o
     * Se controlan las vidas restantes, las animaciones y el fin de la partida
     */
    private void danyo()
    {
        vidas--;
        //Si se agotan las vidas: reproduce el sonido de muerte, animaci�n de da�o y subrutina de muerte
        if (vidas <= 0)
        {
            personajeAS.PlayOneShot(muerte_clip);
            animator.SetTrigger("Da�o");
            StartCoroutine(Muerte());
            
            //Comprobar y guardar nuevos records
            int recordUltimo = PlayerPrefs.GetInt("Mascarillas");
            if (PlayerPrefs.HasKey("Mascarillas") == false)
            {
                //No hay record guardado
                PlayerPrefs.SetInt("Mascarillas", mascarillas);
            }
            else
            {
                //S� hay record guardado, y se han conseguido m�s mascarillas
                if (recordUltimo < mascarillas)
                {
                    //Nuevo record
                    PlayerPrefs.SetInt("Mascarillas", mascarillas);
                }
            }
        }
        //Si no se han agotado las vidas, se ejecuta la subrutina de parpadeo
        else
        {
            StartCoroutine(Parpadeo());               
        }

        PlayerPrefs.SetInt("Mascarillas_actuales", mascarillas);
    }

    /*
     * M�todo que produce que el jugador ignore la colisi�n con el coche tras ser atropellado despu�s de un tiempo determinado
     */
    private IEnumerator choqueCoche()
    {
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GameObject.FindWithTag("Coche").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    /*
     * M�todo que produce un efecto de parpadeo en el jugador cuando sufre un da�o despu�s de un tiempo determinado
     */
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

    /*
     * M�todo que produce el cambio de escena despu�s de un tiempo determinado
     */
    private IEnumerator Muerte()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("GameOver");
    }
}
