using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script que gestiona el comportamiento del botón de sonido del menú principal
 */
public class CambiarSonido : MonoBehaviour
{
    public Sprite boton_on;
    public Sprite boton_off;
    public Button btn;
    private Musica music;

    /*
     * Método que se ejecuta cuando se inicia el script
     * Obtiene un objeto de la clase Música y ejecuta el método 'ActualizarIcono'
     */
    void Start()
    {
        music = GameObject.FindObjectOfType<Musica>();
        ActualizarIcono();
    }

    /*
     * Método que se ejecuta cuando se presiona el botón sonido
     * Ejecuta el método 'cambiarSonido' de la clase Música y actualiza el icono
     */
    public void PausarMusica()
    {
        music.cambiarSonido();
        ActualizarIcono();
    }

    /*
     * Método que obtiene las preferencias de sonido almacenadas 
     * y cambia el icono del botón de sonido en función de si el sonido está activado o no
     */
    void ActualizarIcono()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 0.3f;
            btn.GetComponent<Image>().sprite = boton_on;
        } else
        {
            AudioListener.volume = 0;
            btn.GetComponent<Image>().sprite = boton_off;
        }
    }

        
}
