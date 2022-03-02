using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script para la selección del personaje de la escena 'SeleccionPersonaje'
 */
public class SeleccionPersonaje : MonoBehaviour
{
    /*
     * Método que se ejecuta en cada fotograma, si MonoBehaviour está activo
     * Cuando se pulsa la tecla de Escape (Esc), se vuelve a la escena de menú principal
     */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }    
    }

    /*
     * Método que se ejecuta cuando se presiona sobre la imagen correspondiente al personaje Carmen
     * Establece que el personaje con el que se jugará la partida será Carmen y cambia a la escena de juego
     */
    public void onCarmenPress()
    {
        PlayerPrefs.SetInt("JugadorSel", 0);
        SceneManager.LoadScene("CoronAttack");
    }

    /*
     * Método que se ejecuta cuando se presiona sobre la imagen correspondiente al personaje Fernando
     * Establece que el personaje con el que se jugará la partida será Fernando y cambia a la escena de juego
     */
    public void onFernandoPress()
    {
        PlayerPrefs.SetInt("JugadorSel", 1);
        SceneManager.LoadScene("CoronAttack");
    }

    
}
