using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Script para la gestión general de la escena de juego
 */
public class GameManager : MonoBehaviour
{
    public Text vidas_txt;
    public Text mascarilla_txt;
    private PlayerController jugador;

    public GameObject[] personajes;
    
    public Transform posicionInicial;
    int personajeSelec;
    public GameObject jug;

    public Sprite[] imagenes;
    public Image imagen_vidas;

    /*
     * Método que se ejecuta al cargar el script
     * Bloquea el cursor para que no sea visible en pantalla
     * Instancia el personaje seleccionado en la escena de selección de personajes
     * y cambia la imagen que aparece en el panel de juego que representa las vidas del jugador
     */
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        personajeSelec = PlayerPrefs.GetInt("JugadorSel", 0);
        jug = Instantiate(personajes[personajeSelec], posicionInicial.position, personajes[personajeSelec].transform.rotation);

        jugador = jug.GetComponent<PlayerController>();

        imagen_vidas.GetComponent<Image>().sprite = imagenes[personajeSelec];
    }
    
    /*
     * Método que se ejecuta una vez por fotograma
     * Establece el texto que aparece en el panel de vidas y mascarillas 
     * según vayan cambiando los valores durante el juego
     * Si se presiona la tecla Esc, se vuelve al menú principal
     */
    void Update()
    {
        if(jugador.Vidas >= 0)
        {
            vidas_txt.text = "X " + jugador.Vidas.ToString();
        } else
        {
            vidas_txt.text = "X 0";
        }
        
        mascarilla_txt.text = "X " + jugador.Mascarillas.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    
}
