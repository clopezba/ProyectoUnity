using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script que gestiona el comportamiento del bot�n de sonido del men� principal
 */
public class CambiarSonido : MonoBehaviour
{
    public Sprite boton_on;
    public Sprite boton_off;
    public Button btn;
    private Musica music;

    /*
     * M�todo que se ejecuta cuando se inicia el script
     * Obtiene un objeto de la clase M�sica y ejecuta el m�todo 'ActualizarIcono'
     */
    void Start()
    {
        music = GameObject.FindObjectOfType<Musica>();
        ActualizarIcono();
    }

    /*
     * M�todo que se ejecuta cuando se presiona el bot�n sonido
     * Ejecuta el m�todo 'cambiarSonido' de la clase M�sica y actualiza el icono
     */
    public void PausarMusica()
    {
        music.cambiarSonido();
        ActualizarIcono();
    }

    /*
     * M�todo que obtiene las preferencias de sonido almacenadas 
     * y cambia el icono del bot�n de sonido en funci�n de si el sonido est� activado o no
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
