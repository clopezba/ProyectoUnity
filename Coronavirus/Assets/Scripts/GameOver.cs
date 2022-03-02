using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Script para la gestión de la escena de GameOver
 */
public class GameOver : MonoBehaviour
{
    public Text record_txt;
    public Text actual_txt;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip musica;
    public AudioClip beep;
    
    public Sprite carmen_img;
    public Sprite fernando_img;
    public Image img;

    /*
     * Método que se ejecuta al cargar la escena
     * Ejecuta el método ActualizarImagen y reproduce la música corresondiente a la escena
     */
    void Awake()
    {
        ActualizarImagen();
        source.PlayOneShot(musica);
    }

    /*
     * Método que se ejecuta al iniciar la escena
     * Restaura el cursor para que aparezca en pantalla
     * Muestra el record actual de mascarillas recogidas en una partida y las mascarillas que se han recogido en la partida actual
     */
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        record_txt.text = "Record ............... " + PlayerPrefs.GetInt("Mascarillas").ToString();
        actual_txt.text = "Punt. actual ......... " + PlayerPrefs.GetInt("Mascarillas_actuales").ToString();
    }

    /*
     * Método que se ejecuta al pulsar el botón Restart
     * Se carga la escena de juego (CoronAttack)
     */
    public void Jugar()
    {
        SceneManager.LoadScene("CoronAttack");
    }

    /*
     * Método que se ejecuta al pulsar el botón Menu
     * Se carga la escena de menú principal
     */
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*
     * Método que se ejecuta al pulsar el botón Salir
     * Sale de la aplicación
     */
    public void Salir() 
    {
        Application.Quit();
    }

    /*
     * Método que establece el sonido que se reproducirá al presionar los botones
     */
    public void ReproducirSonido()
    {
        source.PlayOneShot(beep);
    }

    /*
     * Método para cambiar la imagen de la escena en función del personaje con el que se ha jugado
     */
    void ActualizarImagen()
    {
        if (PlayerPrefs.GetInt("JugadorSel") == 0)
        {
            img.GetComponent<Image>().sprite = carmen_img;
        }
        else
        {   
            img.GetComponent<Image>().sprite = fernando_img;
        }
    }

}
