using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Script para la gesti�n de la escena de GameOver
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
     * M�todo que se ejecuta al cargar la escena
     * Ejecuta el m�todo ActualizarImagen y reproduce la m�sica corresondiente a la escena
     */
    void Awake()
    {
        ActualizarImagen();
        source.PlayOneShot(musica);
    }

    /*
     * M�todo que se ejecuta al iniciar la escena
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
     * M�todo que se ejecuta al pulsar el bot�n Restart
     * Se carga la escena de juego (CoronAttack)
     */
    public void Jugar()
    {
        SceneManager.LoadScene("CoronAttack");
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n Menu
     * Se carga la escena de men� principal
     */
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n Salir
     * Sale de la aplicaci�n
     */
    public void Salir() 
    {
        Application.Quit();
    }

    /*
     * M�todo que establece el sonido que se reproducir� al presionar los botones
     */
    public void ReproducirSonido()
    {
        source.PlayOneShot(beep);
    }

    /*
     * M�todo para cambiar la imagen de la escena en funci�n del personaje con el que se ha jugado
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
