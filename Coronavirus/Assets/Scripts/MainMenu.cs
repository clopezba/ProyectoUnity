using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script para la gesti�n del men� principal
 */
public class MainMenu : MonoBehaviour
{
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;
    public GameObject creditos_pn;
    public GameObject instrucciones_pn;

    /*
     * M�todo que se ejecuta al iniciar la escena
     * Restaura el cursor para que se vea en pantalla
     */
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    /*
     * M�todo que permite a�adir un sonido a los botones cuando son pulsados
     */
    public void ReproducirSonido()
    {
       source.PlayOneShot(clip);
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n Jugar
     * Carga la escena de selecci�n de jugador
     */
    public void Jugar()
    {
        SceneManager.LoadScene("SeleccionPersonaje");
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n Cr�ditos
     * Muestra el panel de cr�ditos
     */
    public void Creditos()
    {
        creditos_pn.SetActive(true);
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n Cerrar del panel de cr�ditos
     * Oculta el panel de cr�ditos
     */
    public void creditosCerrar()
    {
        creditos_pn.SetActive(false);
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n de instrucciones (i)
     * Muestra el panel de instrucciones
     */
    public void Instrucciones()
    {
        instrucciones_pn.SetActive(true);
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n Cerrar del panel de instrucciones
     * Oculta el panel de instrucciones
     */
    public void instruccionesCerrar()
    {
        instrucciones_pn.SetActive(false);
    }

    /*
     * M�todo que se ejecuta al pulsar el bot�n Salir
     * Sale de la aplicaci�n
     */
    public void Salir()
    {
        Application.Quit();
    }
}
