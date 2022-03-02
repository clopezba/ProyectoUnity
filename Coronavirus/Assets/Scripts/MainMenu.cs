using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script para la gestión del menú principal
 */
public class MainMenu : MonoBehaviour
{
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;
    public GameObject creditos_pn;
    public GameObject instrucciones_pn;

    /*
     * Método que se ejecuta al iniciar la escena
     * Restaura el cursor para que se vea en pantalla
     */
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    /*
     * Método que permite añadir un sonido a los botones cuando son pulsados
     */
    public void ReproducirSonido()
    {
       source.PlayOneShot(clip);
    }

    /*
     * Método que se ejecuta al pulsar el botón Jugar
     * Carga la escena de selección de jugador
     */
    public void Jugar()
    {
        SceneManager.LoadScene("SeleccionPersonaje");
    }

    /*
     * Método que se ejecuta al pulsar el botón Créditos
     * Muestra el panel de créditos
     */
    public void Creditos()
    {
        creditos_pn.SetActive(true);
    }

    /*
     * Método que se ejecuta al pulsar el botón Cerrar del panel de créditos
     * Oculta el panel de créditos
     */
    public void creditosCerrar()
    {
        creditos_pn.SetActive(false);
    }

    /*
     * Método que se ejecuta al pulsar el botón de instrucciones (i)
     * Muestra el panel de instrucciones
     */
    public void Instrucciones()
    {
        instrucciones_pn.SetActive(true);
    }

    /*
     * Método que se ejecuta al pulsar el botón Cerrar del panel de instrucciones
     * Oculta el panel de instrucciones
     */
    public void instruccionesCerrar()
    {
        instrucciones_pn.SetActive(false);
    }

    /*
     * Método que se ejecuta al pulsar el botón Salir
     * Sale de la aplicación
     */
    public void Salir()
    {
        Application.Quit();
    }
}
